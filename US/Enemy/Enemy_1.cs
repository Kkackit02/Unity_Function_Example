using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : LivingEntity
{
        public Transform Player;

        public enum State
        {
                IDLE,
                TRACE,
                PATROL,
                ATTACK,
                DIE
        }




        


        public Transform[] points;
        public int Idx = 1;

        private LivingEntity targetEntity;

        public float damage = 20f;
        public float AttackRate = 0.5f;
        public float attackDist = 1.0f;
        public float lastAttackTime;
        public float speed = 2.0f;
        public float TraceSpeed = 4.0f;


        private Transform tr;
        private Transform playerTr;
        private Vector3 movePos;

        public float detectPoint;
        private float MaxDistance = 15.0f;

        private int hashRun = Animator.StringToHash("IsRun_E");
        private int hashWalk = Animator.StringToHash("IsWalk_E");
        private int hashAttack = Animator.StringToHash("IsAttack_E");

        public State state = State.IDLE;


        private bool isAttack = false;
        public bool isDie = false;

        public GameObject fog_left;
        public GameObject fog_right;

        private WaitForSeconds ws;

        
 
        RaycastHit2D hit;


        private SpriteRenderer spriterenderer;
        private SpriteRenderer fog_spriterenderer;
        private Animator enemyAnimator;
        private AudioSource enemyAudioPlayer;


        public AudioClip deathSound;
        public AudioClip hitSound;
        public DataManager datamanager;

        private Vector3 EnemyPosition;
        private Vector3 scale;
        private float Up_Detect;
        private float Down_Detect;


        void Start()
        {

                

                Player = GameObject.FindGameObjectWithTag("Player").transform;

                spriterenderer = GetComponent<SpriteRenderer>();

                datamanager = GameObject.Find("DataManager").GetComponent<DataManager>();
                detectPoint = datamanager.defalt_detectPoint;
                TraceSpeed = datamanager.melee_EnemyRun_Speed;
                speed = datamanager.melee_EnemyWalk_Speed;


                Up_Detect = datamanager.Up_detect;
                Down_Detect = datamanager.Down_detect;


                attackDist = datamanager.melee_EnemyAttack_Distance;
                MaxDistance = datamanager.melee_Enemy_Detect_Distance;
                tr = GetComponent<Transform>();
                playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
                points = GameObject.Find("WayPointGroup").GetComponentsInChildren<Transform>();

                enemyAnimator = GetComponent<Animator>();
                enemyAudioPlayer = GetComponent<AudioSource>();
                isDie = false;

                StartCoroutine("CheckMonsterState");
                StartCoroutine("MonsterAction");
                StartCoroutine("DetectPoint");
        }

        void Update()
        {

                //Debug.Log("detect");
                //Debug.Log(state);
                EnemyPosition = this.gameObject.transform.position;


                if (isAttack == false)
                {
                        if (state == State.PATROL)
                        {
                                Patrol();
                        }

                        else if (state == State.IDLE)
                        {
                                Idle();
                        }

                        else if (state == State.TRACE)
                        {
                                Trace();
                        }


                        else if (state == State.ATTACK)
                        {
                                Attack();
                        }


                        else if (state == State.DIE)
                        {
                                Die();
                        }
                }


                
        }


                

 
        IEnumerator CheckMonsterState()
        {
                while (!isDie)
                {
                        yield return ws;

                        float dist = Vector3.Distance(this.gameObject.transform.position, playerTr.position);
                        //몬스터와 주인공간의 거리가 공격사정거리 이내인 경우
                        if (dist <= attackDist)
                        {
                                state = State.ATTACK;
                        }
                        //공격사정거리보다 크고 추적사정거리 이내인 경우

                        else if (detectPoint > 50)
                        {
                                state = State.TRACE;
                        }
                        else if (detectPoint > 20 && detectPoint <= 50 )
                        {
                                state = State.PATROL;
                        }

                        
                        else if (detectPoint <= 20)
                        {
                                state = State.IDLE;
                        }



                }
        }


        IEnumerator MonsterAction()
        {
                while (!isDie)
                {
                        switch (state)
                        {
                                case State.IDLE:

                                        enemyAnimator.SetBool(hashWalk, false);
                                        enemyAnimator.SetBool(hashAttack, false);
                                        break;

                                case State.PATROL:

                                        enemyAnimator.SetBool(hashWalk, true);
                                        enemyAnimator.SetBool(hashAttack, false);

                                        break;


                                case State.TRACE:

                                        enemyAnimator.SetBool(hashRun, true);
                                        enemyAnimator.SetBool(hashWalk, false);
                                        enemyAnimator.SetBool(hashAttack, false);

                                        break;

                                case State.ATTACK:

                                        enemyAnimator.SetBool(hashAttack, true);
                                        break;

                                case State.DIE:
                                        break;


                        }
                        yield return ws;


                }

        }

        IEnumerator DetectPoint()
        {
                while (!isDie)
                {
                        yield return new WaitForSeconds(0.2f);

                        if (spriterenderer.flipX == false)
                        {
                                RaycastHit2D hit = Physics2D.Raycast(EnemyPosition, Vector2.left, MaxDistance);
                                Debug.DrawRay(EnemyPosition, Vector2.left * MaxDistance, Color.red, 0.3f);

                                if (hit.collider != null)
                                {
                                        //Debug.Log("적 레이 인식");
                                        string name = hit.collider.gameObject.name;

                                        if (name.Equals("Player_M"))
                                        {
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
                                        detectPoint -= Down_Detect;
                                }

                                

                                

                        }

                        if (spriterenderer.flipX == true)
                        {
                                RaycastHit2D hit = Physics2D.Raycast(EnemyPosition, Vector2.right, MaxDistance);
                                Debug.DrawRay(EnemyPosition, Vector2.right * MaxDistance, Color.red, 0.3f);


                                if (hit.collider != null)
                                {
                                        Debug.Log("적 레이 인식");
                                        string name = hit.collider.gameObject.name;
                                        Debug.Log(name);
                                        if (name.Equals("Player_M"))
                                        {
                                                Debug.Log("발각!");
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
                                        Debug.Log("적 레이 인식X");
                                        detectPoint -= (Down_Detect);
                                }

                                

                                
                        }


                }
                yield return ws;
        }






        public void Setup(float newHealth, float newDamage, float newSpeed)
        {
                startingHealth = newHealth;
                health = newHealth;

                damage = newDamage;
                //speed = newspeed;
        }

        public override void OnDamage(float damage)
        {
                base.OnDamage(damage);

                if (dead == false)
                {
                        enemyAudioPlayer.PlayOneShot(hitSound);
                }
        }

        public override void Die()
        {
                base.Die();

                enemyAnimator.SetTrigger("Die");
                enemyAudioPlayer.PlayOneShot(deathSound);

        }


        private void OnTriggerStay2D(Collider2D collision)
        {
                if (dead == false && Time.time >= lastAttackTime + AttackRate)
                {
                        LivingEntity attackTarget = collision.GetComponent<LivingEntity>();
                        if (attackTarget != null && attackTarget == targetEntity)
                        {
                                lastAttackTime = Time.time;
                                /*
                                attackTarget.OnDamage(damage, dist);
                                */
                        }
                }
        }



        public void OnTriggerEnter2D(Collider2D other)
        {
                if (state == State.PATROL)
                {
                        if (other.transform.tag == "WAY_POINT_PATROL")
                        {
                                //Debug.Log("체크포인트");
                                if (spriterenderer.flipX == true)
                                {
                                        transform.Translate(Vector2.right * 5.0f * Time.deltaTime);
                                }

                                else if (spriterenderer.flipX == false)
                                {
                                        transform.Translate(Vector2.left * 5.0f * Time.deltaTime);
                                }
                                Flip();
                        }
                }

                if (state == State.TRACE)
                {
                        if (other.transform.tag == "WAY_POINT_TRACE")
                        {
                                
                                
                        }
                }

        }


        void Flip()
        {
                Debug.Log("Flip");
                if (spriterenderer.flipX == true)
                {
                        // Debug.Log("Left = false");
                        spriterenderer.flipX = false;
                        fog_left.SetActive(true);
                        fog_right.SetActive(false);
                }

                else if (spriterenderer.flipX == false)
                {
                        //Debug.Log("Left = true");
                        spriterenderer.flipX = true;
                        fog_left.SetActive(false);
                        fog_right.SetActive(true);
                }
                
        }

        void Patrol()
        {

                enemyAnimator.SetBool(hashWalk, true);
                enemyAnimator.SetBool(hashAttack, false);

                if (spriterenderer.flipX == false)
                {
                        transform.Translate(Vector2.left * speed * Time.deltaTime);
                }

                if (spriterenderer.flipX == true)
                {
                        transform.Translate(Vector2.right * speed * Time.deltaTime);
                }

        }


        void Idle()
        {

                enemyAnimator.SetBool(hashWalk, false);
                enemyAnimator.SetBool(hashAttack, false);
                /*
                float Delay = 0;

                Delay += Time.deltaTime;

                if (Delay >= 10f)
                {
                        Flip();
                }
                */

        }


        void Trace()
        {

                enemyAnimator.SetBool(hashRun, true);
                enemyAnimator.SetBool(hashWalk, false);
                enemyAnimator.SetBool(hashAttack, false);

                if (Player != null)
                {
                        Vector3 playerPos = Player.transform.position;
                        if(playerPos.x < transform.position.x)
                        {
                                spriterenderer.flipX = false;
                                transform.Translate(Vector2.left * TraceSpeed * Time.deltaTime);
                        }
                        if (playerPos.x > transform.position.x)
                        {
                                spriterenderer.flipX = true;
                                transform.Translate(Vector2.right * TraceSpeed * Time.deltaTime);
                        }

                }



                        /*
                        if (spriterenderer.flipX == false)
                        {
                                transform.Translate(Vector2.left * TraceSpeed * Time.deltaTime);
                        }

                        if (spriterenderer.flipX == true)
                        {
                                transform.Translate(Vector2.right * TraceSpeed * Time.deltaTime);
                        }
                        */


                        //Vector2 dir = Player.position - transform.position;



                        //transform.position += (Player.position - transform.position).normalized * TraceSpeed * Time.deltaTime;


                
                //플레이어 추격
                //문제는 슬라이드뷰인데 어떻게 추적하죠? Navigaton을 2d 슬라이드뷰에서 사용가능한가요..?
        }


        void Attack()
        {
                enemyAnimator.SetBool(hashAttack, true);
        }

}


        

