using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : LivingEntity  
{
        public Slider healthSlider;

        private Player_Ctr player_Ctr;
        private Animator player_ani;
        public GameObject Player;

        public GameObject RestartMenu;

        public Rigidbody2D player_rid;

        public bool isdie = false;
        private void Awake()
        {
                player_rid = Player.GetComponent<Rigidbody2D>();
                player_ani = Player.GetComponent<Animator>();
                player_Ctr = Player.GetComponent<Player_Ctr>();

        }


        protected override void OnEnable()
        {
                base.OnEnable(); //상태 초기화

                healthSlider.gameObject.SetActive(true); // 슬라이더 활성화

                healthSlider.maxValue = startingHealth; // 최댓값을 기본 체력값으로 변경

                healthSlider.value = health; //슬라이더값을 현재 체력값으로 변경

                player_Ctr.enabled = true;
                player_ani.enabled = true;

        }




        public override void RestoreHealth(float newHealth)
        {
                base.RestoreHealth(newHealth);

                healthSlider.value = health; //갱신된 체력으로 체력슬라이더 갱신
        }



        public override void OnDamage(float damage)
        {

                if (dead == false)
                {
                        //소리
                }
                
                base.OnDamage(damage);
                healthSlider.value = health;

                

               


        }



        public override void Die()
        {
                base.Die();

                isdie = true;
                player_ani.SetTrigger("Die");
                healthSlider.gameObject.SetActive(false);
                //player_ani.enabled = false;
                player_Ctr.isMove = false;
                Invoke("OnPanal", 0.7f);
                
                //소리

                


        }


        void OnPanal()
        {
                RestartMenu.SetActive(true);
        }

        private void OnTriggerEnter(Collider other)
        {
                if (dead == false)
                {

                        /*
                        IItem item = other.GetComponent<IItem>();


                        if (item != null)
                        {
                                item.Use(gameObject);
                                //소리 
                        }
                        */
                }
        }

        private void Update()
        {
                
               
        }


}
