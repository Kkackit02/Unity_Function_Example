using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
        public GameObject AttackColider;

        public string dist = "";
        private bool isAttack = false;

        public PlayerHealth playerhealth;
        public Player_Ctr player_ctr;

        private SpriteRenderer spriterenderer;
        Vector3 moveVelocity = Vector3.zero;
        public float walkSpeed;
        public float runSpeed;

        public float Speed;
        public bool isDie = false;

        public float Enemy_Damage;

        public int creatureType;
        public bool isTracing = false;
        public GameObject traceTarger;

        

        public float MaxDistance;

        DataManager datamanager;
        Animator animator;
        Vector3 movement;
        private Vector3 EnemyPosition;
        public int movementFlag = 0;


        private int hashRun = Animator.StringToHash("IsRun_E");
        private int hashWalk = Animator.StringToHash("IsWalk_E");
        private int hashAttack = Animator.StringToHash("IsAttack_E");


        private float Up_Detect;
        private float Down_Detect;
        public float detectPoint;

        public GameObject Look_L;
        public GameObject Look_R;


        private WaitForSeconds ws;

        
        public CapsuleCollider2D CC;

        public BoxCollider2D Left_BoxC;

        public BoxCollider2D Right_BoxC;

        public BoxCollider2D Bottle;
        int stop;

        int layerMask = 1 << 8;

        public bool enemy_Die = false;

        public Rigidbody2D rid;
        public int Type;
        public bool Destroy_Enemy = false;
        public AudioSource AS;
        public AudioClip attack;
        public AudioClip attacked;

        public void Start()
    {
                rid = this.gameObject.GetComponent<Rigidbody2D>();

                CC = GetComponent<CapsuleCollider2D>();
                AS = GetComponent<AudioSource>();
                datamanager = GameObject.Find("DataManager").GetComponent<DataManager>();
                animator = gameObject.GetComponentInChildren<Animator>();
                walkSpeed = datamanager.melee_EnemyWalk_Speed;
                runSpeed = datamanager.melee_EnemyRun_Speed;
                playerhealth = GameObject.Find("PlayerHealth").GetComponent<PlayerHealth>();
                player_ctr = GameObject.Find("Player_M").GetComponent<Player_Ctr>();
                MaxDistance = datamanager.melee_Enemy_Detect_Distance;
                spriterenderer = GetComponent<SpriteRenderer>();
                traceTarger = GameObject.Find("Player_M");
                
                Enemy_Damage = datamanager.melee_EnemyAttack_Damage;
                Up_Detect = datamanager.Up_detect;
                Down_Detect = datamanager.Down_detect;


                movementFlag = 0;
                if (Type == 1)
                {
                        StartCoroutine("ChangeMovement");
                        StartCoroutine("DetectPoint");
                }
                
                isDie = false;
        }


        public void end_Ani()
        {
                animator.enabled = false;
                Destroy(this.gameObject);
                
                CC.enabled = false;


        }      


        
        private void FixedUpdate()
        {

                if (enemy_Die == true)
                {
                        

                        if (stop != 1)
                        {
                                rid.simulated = false;
                                animator.SetTrigger("Die");
                                Left_BoxC.enabled = false;
                                Right_BoxC.enabled = false;
                                
                                Look_L.SetActive(false);
                                Look_R.SetActive(false);
                                stop = 1;
                                StopCoroutine("ChangeMovement");
                                StopCoroutine("DetectPoint");
                                Invoke("end_Ani", 0.8f);
                                Destroy_Enemy = true;
                                isDie = true;
                                animator.SetBool("isDie",Destroy_Enemy);
                        }
                        
                        
                        isDie = true;
                        
                }


                if(isDie == false)
                {

                        if(Type == 1)
                        {
                                EnemyPosition = this.gameObject.transform.position;
                                if (isAttack == false)
                                {
                                        if(movementFlag != 0)
                                        {
                                                Move();
                                        }
                                        if(movementFlag == 0)
                                        {
                                                animator.SetBool(hashWalk, false);
                                        }
                                        
                                        if(detectPoint > 40)
                                        {
                                                Move();
                                                animator.SetBool(hashWalk, true);
                                        }

                                }


                                if (detectPoint > 45)
                                {


                                        isTracing = true;
                                        animator.SetBool("IsRun_E", true);
                                        Speed = runSpeed;
                                }
                                else
                                {
                                        if (detectPoint < 10)
                                        {
                                                isTracing = false;
                                        }

                                        animator.SetBool("IsRun_E", false);
                                        Speed = walkSpeed;

                                }
                        }
                       
                        

                }
               
                else
                {
                        StopAllCoroutines();
                }

              //if(detectPoint )

        }
        





        IEnumerator ChangeMovement()
        {
                if(detectPoint < 10)
                {
                        movementFlag = Random.Range(0, 3);

                        if (movementFlag == 0)
                        {
                                animator.SetBool(hashWalk, false);
                        }

                        else
                        {
                                animator.SetBool(hashWalk, true);
                        }

                }


                yield return new WaitForSeconds(4f);


                StartCoroutine("ChangeMovement");
        }


        IEnumerator Damage_P()
        {
                while(!isDie)
                {
                        if(Destroy_Enemy == false)
                        {
                                animator.SetTrigger("IsAttack_E");
                                yield return new WaitForSeconds(0.7f);
                                player_ctr.KnockBack(dist);

                                AS.PlayOneShot(attack);
                                playerhealth.OnDamage(Enemy_Damage);
                                //isAttack = false;
                                isDie = playerhealth.isdie;

                        }


                }
        }



        IEnumerator DetectPoint()
        {
                while (!isDie)
                {
                        yield return new WaitForSeconds(0.1f);

                        

                        if (spriterenderer.flipX == true)
                        {
                                RaycastHit2D hit = Physics2D.Raycast(EnemyPosition, Vector2.left, MaxDistance, layerMask);
                                Debug.DrawRay(EnemyPosition, Vector2.left * MaxDistance, Color.red, 1f);

                                if (hit.collider != null)
                                {
                                        //Debug.Log("적 레이 인식");
                                        string name = hit.collider.gameObject.name;
                                        //Debug.Log(name + "인식한 콜라이더 이름");
                                        if (name.Equals("Player_M"))
                                        {
                                                //StopCoroutine("ChangeMovement");
                                                //Debug.Log("발각!");
                                                if (detectPoint + Up_Detect >= 100.0f)
                                                {
                                                        detectPoint = 100.0f;
                                                }

                                                else
                                                {
                                                        detectPoint += Up_Detect;
                                                }


                                        }

                                        else
                                        {

                                                if (detectPoint - Down_Detect <= 0.0f)
                                                {
                                                        detectPoint = 0.0f;
                                                }

                                                else
                                                {
                                                        detectPoint -= Down_Detect;
                                                }

                                        }

                                }

                                else
                                {
                                        //Debug.Log("적 레이 인식X");
                                        if (detectPoint > 0)
                                        {
                                                detectPoint -= (Down_Detect);
                                        }
                                }





                        }

                        if (spriterenderer.flipX == false)
                        {
                                RaycastHit2D hit = Physics2D.Raycast(EnemyPosition, Vector2.right, MaxDistance, layerMask);
                                Debug.DrawRay(EnemyPosition, Vector2.right * MaxDistance, Color.red, 0.3f);


                                if (hit.collider != null)
                                {
                                        //Debug.Log("적 레이 인식");
                                        string name = hit.collider.gameObject.name;
                                        //Debug.Log(name + "인식한 콜라이더 이름");
                                        if (name.Equals("Player_M"))
                                        {
                                                //StopCoroutine("ChangeMovement");
                                                //Debug.Log("발각!");
                                                if (detectPoint + Up_Detect >= 100.0f)
                                                {
                                                        detectPoint = 100.0f;
                                                }

                                                else
                                                {
                                                        detectPoint += (Up_Detect);
                                                }


                                        }

                                        else
                                        {

                                                if (detectPoint - Down_Detect <= 0.0f)
                                                {
                                                        detectPoint = 0.0f;
                                                }
                                                else
                                                {
                                                        detectPoint -= (Down_Detect);
                                                }

                                        }

                                }

                                else
                                {
                                       
                                        //Debug.Log("적 레이 인식X");
                                        if (detectPoint > 0)
                                        {
                                                detectPoint -= (Down_Detect);
                                        }
                                        
                                }




                        }


                }
                //StartCoroutine("DetectPoint");
                yield return ws;
        }








        void Move()
        {
                Vector3 moveVelocity = Vector3.zero;
                

                if (isTracing == true)
                {
                        Vector3 PlayerPos = traceTarger.transform.position;

                        if(PlayerPos.x < transform.position.x)
                        {
                                dist = "Left";
                        }

                        else if (PlayerPos.x > transform.position.x)
                        {
                                dist = "Right";
                        }

                }

                else
                {
                        if (movementFlag == 1)
                        {
                                dist = "Left";
                        }
                        else if (movementFlag == 2)
                        {

                                dist = "Right";
                        }
                }

                if(dist == "Left")
                {
                        moveVelocity = Vector3.left;
                        spriterenderer.flipX = true;
                        Look_L.SetActive(true);
                        Look_R.SetActive(false);


                        Left_BoxC.enabled = true;
                        Right_BoxC.enabled = false;

                }
                else if(dist == "Right")
                {

                        Left_BoxC.enabled = false;
                        Right_BoxC.enabled = true;
                        moveVelocity = Vector3.right;
                        spriterenderer.flipX = false;
                        Look_R.SetActive(true);
                        Look_L.SetActive(false);

                }
                

                transform.Translate(moveVelocity * walkSpeed * Time.deltaTime);
        }
        





        void OnTriggerEnter2D (Collider2D other)
        {

                if (enemy_Die == false)
                {


                        //Debug.Log("충돌 체크");
                        if (creatureType == 0)
                        {
                                return;
                        }
                        if (other.gameObject.tag == "Player")
                        {
                                //Debug.Log("충돌 체크1");
                                detectPoint = 100;
                                traceTarger = other.gameObject;
                                StopCoroutine("ChangeMovement");
                                creatureType = 1;
                                Type = 1;



                        }

                        if (other.gameObject.tag == "Wall")
                        {
                                //Debug.Log("충돌 체크2");
                                if (movementFlag == 1)
                                {
                                        movementFlag = 2;
                                        this.gameObject.transform.Translate(Vector3.right * 30 * Time.deltaTime);

                                }
                                else if (movementFlag == 2)
                                {
                                        this.gameObject.transform.Translate(Vector3.left * 30 * Time.deltaTime);
                                        movementFlag = 1;


                                }
                        }


                        if (other.gameObject.tag == "Player")
                        {
                                if (isDie == false)
                                {
                                        animator.SetBool("IsRun_E", false);
                                        animator.SetBool("IsWalk_E", false);

                                        if (isAttack == false)
                                        {
                                                StartCoroutine("Damage_P");
                                                isAttack = true;
                                        }

                                        movementFlag = 0;
                                }
                        }

                        if (other.gameObject.tag == "Box")
                        {
                                if (detectPoint > 45)
                                {
                                        if (isDie == false)
                                        {

                                                AttackColider.SetActive(true);

                                        }
                                }

                                if (detectPoint <= 30)
                                {
                                        if (movementFlag == 1)
                                        {
                                                movementFlag = 2;
                                                this.gameObject.transform.Translate(Vector3.right * 30 * Time.deltaTime);

                                        }
                                        else if (movementFlag == 2)
                                        {
                                                this.gameObject.transform.Translate(Vector3.left * 30 * Time.deltaTime);
                                                movementFlag = 1;


                                        }
                                }

                        }
                        if (other.gameObject.tag == "roof")
                        {
                                if (movementFlag == 1)
                                {
                                        movementFlag = 2;
                                        this.gameObject.transform.Translate(Vector3.right * 30 * Time.deltaTime);

                                }
                                else if (movementFlag == 2)
                                {
                                        this.gameObject.transform.Translate(Vector3.left * 30 * Time.deltaTime);
                                        movementFlag = 1;


                                }
                        }



                        if (Bottle.gameObject.tag == "throw")
                        {
                                //Debug.Log("인식");
                                if (detectPoint < 30)
                                {
                                        detectPoint += 30;

                                        if (Bottle.gameObject.transform.position.x > gameObject.transform.position.x)
                                        {
                                                movementFlag = 2;
                                                //Debug.Log("오른쪽 인식");
                                        }

                                        if (Bottle.gameObject.transform.position.x > gameObject.transform.position.x)
                                        {
                                                movementFlag = 1;
                                                //Debug.Log("왼쪽 인식");
                                        }

                                }


                        }


                        if(other.gameObject.tag == "Die")
                        {
                                enemy_Die = true;
                        }
                }

        }







        void OnTriggerExit2D(Collider2D other)
        {
                if (creatureType == 0)
                {
                        return;
                }

                if (other.gameObject.tag == "Player")
                {


                        StopCoroutine("Damage_P");
                        isAttack = false;
                        Vector3 PlayerPos = traceTarger.transform.position;

                        if (PlayerPos.x < transform.position.x)
                        {
                                movementFlag = 1;
                        }

                        else if (PlayerPos.x > transform.position.x)
                        {
                                movementFlag = 2;
                        }
                }

                if (other.gameObject.tag == "Box")
                {
                        AttackColider.SetActive(false);

                }
        }

        

        
}
