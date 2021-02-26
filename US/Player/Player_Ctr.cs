using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Ctr : MonoBehaviour
{

        public GameObject AttackDist_L;
        public GameObject AttackDist_R;
        public PlayerHealth playerhealth;
        
        public bool now_Axis = false; //false - 왼쪽, true - 오른쪽

        public Animator ani;
        public Rigidbody2D rd;
        float speed = 4.0f; //스피드 
        public bool isAttack = false;
        public bool isGround = false;

        public bool isMove = true;

        public float xMove;
        public bool isRun = false;
        public bool isJump = false;
        public DataManager datamanager;
        public Cheak_JoyStickPosition moveJoy;

        private float DelayT;
        private float DelayT_J;
        private SpriteRenderer SpriteRenderer;
        private int hashRun = Animator.StringToHash("IsRun");
        private int hashIdle = Animator.StringToHash("IsIdle");
        private int hashWalk = Animator.StringToHash("IsWalk");
        private int hashAttack = Animator.StringToHash("IsAttack");
        private int hashJump = Animator.StringToHash("IsJump");
        private float AxisX;
        private float AxisY;

        public AudioSource AS;

        public GameObject Interact_target;
        bool isInteract = false;
        private bool isTestMode = false;


        public AudioClip Run;
        public AudioClip Walk1;
        public AudioClip Attack;
        public AudioClip Death;
        public AudioClip Hit;
        public AudioClip JumpSound;

        //********************** 싱글톤 사용법*******************************

        bool isPlaying = false;


        

        public void Start()
        {
                Application.targetFrameRate = 60;
                playerhealth = GameObject.Find("PlayerHealth").GetComponent<PlayerHealth>();
                //Data.PlayerRun_Speed = 10;
                //xMove = Data.PlayerRun_Speed;
                datamanager = GameObject.Find("DataManager").GetComponent<DataManager>();
                moveJoy = GameObject.Find("Cheak").GetComponent<Cheak_JoyStickPosition>();
                SpriteRenderer = GetComponent<SpriteRenderer>();
                ani = GetComponent<Animator>();
                rd = GetComponent<Rigidbody2D>();
                DelayT = 0;
                speed = datamanager.PlayerWalk_Speed;
                AS = GetComponent<AudioSource>();
                AS.loop = true;
        }

        void Update()
        {







                AxisX = moveJoy.Horizontal;
                
                //AxisY = moveJoy.Vertical;
                //isAttack = FindObjectOfType<Cheak_PlayerAttack>().isA;
                if(Input.GetKeyDown(KeyCode.I))
                {
                        if (isTestMode == true)
                        {
                               isTestMode = false;
                        }
                        else
                        {
                               isTestMode = true;
                        }
                }

                if(isTestMode == true)
                {
                        if (Input.GetKey(KeyCode.A))
                        {
                                AxisX = -1;
                        }


                        else if (Input.GetKey(KeyCode.D))
                        {
                                        AxisX = 1;
      
                        }
                        else
                        {
                                AxisX = 0;

                                isPlaying = false;
                                isRun = false;
                        }

                        /*
                        if (Input.GetKey(KeyCode.LeftShift) == true)
                        {
                                ani.SetBool(hashRun, true);
                                speed = datamanager.PlayerRun_Speed;

                                if (SceneManager.GetActiveScene().name == "2-1 Forest")
                                {
                                    ani.SetFloat("run", 1f);
                                }
                                else
                                {
                                    ani.SetFloat("run", 1.3f);
                                }

                        
                                        isRun = true;
                                }
                        else
                        {
                                ani.SetBool(hashRun, false);
                                speed = datamanager.PlayerWalk_Speed;
                                if (SceneManager.GetActiveScene().name == "2-1 Forest")
                                {
                                    ani.SetFloat("run", 0.9f);
                                }
                                else
                                {
                                    ani.SetFloat("run", 1.0f);
                        }
                                        isRun = false;
                        }
                        */


                }





                //Debug.Log(Input.GetAxis("Horizontal"));
                //float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //x축으로 이동할 양 

                float xMove = AxisX * speed * Time.deltaTime;

               

                if (isMove == true)
                {

                        this.transform.Translate(new Vector3(xMove, 0, 0));


                        if (AxisX < 0)
                        {
                                ani.SetBool(hashWalk, true);
                                SpriteRenderer.flipX = true;
                                DelayT = 0;
                                now_Axis = false;
                                ani.SetBool(hashWalk, true);
                        }

                        else if (AxisX > 0)
                        {
                                ani.SetBool(hashWalk, true);
                                SpriteRenderer.flipX = false;
                                DelayT = 0;
                                now_Axis = true;
                                ani.SetBool(hashWalk, true);

                        }
                        else if (AxisX == 0)
                        {

                                ani.SetBool(hashIdle, true);
                                DelayT += Time.deltaTime;
                                if (DelayT > 0.15f)
                                {

                                        ani.SetBool(hashWalk, false);
                                        DelayT = 0;
                                }

                        }

                }



                //float yMove = Input.GetAxis("Vertical") * speed * Time.deltaTime; //y축으로 이동할양 
                /*
                if (isAttack == false)
                {
                        this.transform.Translate(new Vector3(xMove, 0, 0));  //이동
                }
                */

                //이동




                if (isRun == true)
                {
                        ani.SetBool(hashRun, true);
                        speed = datamanager.PlayerRun_Speed;
                        if (SceneManager.GetActiveScene().name == "2-2 Forest")
                        {
                                ani.SetFloat("run", 1f);
                        }
                        else
                        {
                                ani.SetFloat("run", 1.3f);

                        }
                }
                else
                {
                        ani.SetBool(hashRun, false);
                        speed = datamanager.PlayerWalk_Speed;

                        if (SceneManager.GetActiveScene().name == "2-2 Forest")
                        {
                                ani.SetFloat("run", 0.9f);
                        }
                        else
                        {
                                ani.SetFloat("run", 1.0f);
                        }

                }











        }


        


        private void OnTriggerEnter2D(Collider2D collision)
        {
                if(collision.tag == "Die")
                {

                        playerhealth.OnDamage(1500f);

                }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
                if (collision.transform.tag == "Ground")
                {


                        if (AxisX == 0)
                        {

                                //AxisX = 0;
                                AS.Stop();

                                isRun = false;

                        }
                        else
                        {
                                
                                isRun = moveJoy.isRun;
                                if (isRun == true)
                                {
                                        AS.clip = Run;

                                }
                                else if (isRun == false)
                                {
                                        AS.clip = Walk1;

                                }
                                if (!AS.isPlaying)
                                {

                                        
                                        AS.Play();





                                }


                        }
                        DelayT_J = 0;
                        ani.SetBool(hashJump, false);
                        isGround = true;
                        isJump = false;




                }

                
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
                if (collision.transform.tag == "Ground")
                {
                        AS.Stop();

                        isJump = false;
                        Interact_target = null;
                        DelayT_J += Time.deltaTime;
                        isGround = false;
                        
                        if (DelayT_J > 0.02f)
                         {
                                 ani.SetBool(hashJump, true);
                         }

                }
        }


        public void Jump()
        {
                if (isGround == true)
                {
                        ani.SetBool(hashJump, true);
                        rd.AddForce(Vector2.up * datamanager.PlayerJump_Power);
                        AS.PlayOneShot(JumpSound);
                }


        }

        public void Attack_break()
        {
                
                isMove = true;
                if(now_Axis == false)
                {
                        AttackDist_L.SetActive(true);
                }
                if(now_Axis == true)
                {
                        AttackDist_R.SetActive(true);
                }
                
                Invoke("Attack_break2", 0.2f);
                isAttack = false;

                

        }

        public void Invoke_Attack()
        {
                if(isAttack == false)
                {
                        ani.SetTrigger(hashAttack);
                        isMove = false;
                        isAttack = true;
                        Invoke("Attack_break", 0.8f);
                        AS.PlayOneShot(Attack);
                }
                
        }

        public void Attack_break2()
        {
                AttackDist_R.SetActive(false);
                AttackDist_L.SetActive(false);
        }


        public void KnockBack(string dist)
        {
                AS.PlayOneShot(Hit);
                Vector2 attackedVelocity = Vector2.zero;

                if (dist == "Left")
                {
                        attackedVelocity = new Vector2(-2f, 1f);

                }
                if (dist == "Right")
                {
                        attackedVelocity = new Vector2(2f, 1f);

                }
                rd.AddForce(attackedVelocity, ForceMode2D.Impulse);
        }

        public void RestoreHealth()
        {
                playerhealth.RestoreHealth(100);
        }

      

        /*
        public void Knock_Back()
        {
                if (SpriteRenderer.flipX == true)
                {
                        rd.AddForce(Vector2.up * datamanager.Knock_Back_Power);
                        rd.AddForce(Vector2.right * datamanager.Knock_Back_Power);
                }
                if (SpriteRenderer.flipX == false)
                {
                        rd.AddForce(Vector2.up * datamanager.Knock_Back_Power);
                        rd.AddForce(Vector2.left * datamanager.Knock_Back_Power);
                }
        }
        */



        
}


