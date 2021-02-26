using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
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

      


        private WaitForSeconds ws;

        int stop;

        int layerMask = 1 << 8;

        public bool enemy_Die = false;


        public int Type;

        public AudioSource AS;
        public AudioClip attack;
        public AudioClip attacked;

        public void Start()
    {

                
                
                AS = GetComponent<AudioSource>();
                datamanager = GameObject.Find("DataManager").GetComponent<DataManager>();
                
                walkSpeed = datamanager.melee_EnemyWalk_Speed;
                runSpeed = datamanager.melee_EnemyRun_Speed;
                playerhealth = GameObject.Find("PlayerHealth").GetComponent<PlayerHealth>();
                player_ctr = GameObject.Find("Player_M").GetComponent<Player_Ctr>();
                MaxDistance = datamanager.melee_Enemy_Detect_Distance;
                spriterenderer = GetComponent<SpriteRenderer>();
                traceTarger = GameObject.Find("Player_M");

                Enemy_Damage = datamanager.melee_EnemyAttack_Damage;
                


 
                isDie = false;
        }


        public void end_Ani()
        {
                animator.enabled = false;
                Destroy(this.gameObject);
        }
        private void FixedUpdate()
        {



                if(isDie == false)
                {

                        if(Type == 1)
                        {
                                EnemyPosition = this.gameObject.transform.position;
                                Move();
                                isTracing = true;

                        }
                       
                        

                }
               
                else
                {

                }

              //if(detectPoint )

        }
        






        void Move()
        {

                

                if (isTracing == true)
                {
                        Vector3 PlayerPos = traceTarger.transform.position;

                        if(PlayerPos.x < transform.position.x)
                        {
                                transform.Translate(Vector3.left * runSpeed * Time.deltaTime);
                        }

                        else if (PlayerPos.x > transform.position.x)
                        {
                                transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
                        }

                }

        }
        





        void OnTriggerEnter2D (Collider2D other)
        {
                //Debug.Log("충돌 체크");
                if (creatureType == 0)
                {
                        return;
                }
                if(other.gameObject.tag == "Player")
                {
                        //Debug.Log("충돌 체크1");

                        playerhealth.OnDamage(Enemy_Damage);


                }
   
                if(other.gameObject.tag == "throw")
                {

                        isDie = true;
                        

                }
                

        }



        
}
