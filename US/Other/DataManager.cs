using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DataManager : MonoBehaviour
{

        //
        public GameObject PlayerHealth;


        public float Knock_Back_Power = 80.0f;

        public float PlayerWalk_Speed;
        public float PlayerRun_Speed;
        public float PlayerJump_Power;
        public float PlayerAttack_Damage;

        public float defalt_detectPoint;

        public float melee_EnemyWalk_Speed;
        public float melee_EnemyRun_Speed;
        public float melee_EnemyAttack_Damage;
        public float melee_Enemy_Detect_Distance;

        public float Throw_Power = 80.0f;
        public float Up_detect = 10.0f;
        public float Down_detect = 0.5f;
        public float melee_EnemyAttack_Distance;


        public float CCTV_Distance;
        private static DataManager s_datamanager = null;

        public static DataManager Data
        {

                get
                {
                        if (s_datamanager == null)
                        {
                                s_datamanager = FindObjectOfType(typeof(DataManager)) as DataManager;

                                if (s_datamanager = null)
                                {
                                        GameObject obj = new GameObject("Data");
                                        s_datamanager = obj.AddComponent(typeof(DataManager)) as DataManager;
                                }
                        }

                        return s_datamanager;
                }
        }


        private void Awake()
        {



                //PlayerHealth.GetComponent<PlayerHealth>().

                Player_Information();
                MeleeEnemy_Information();
                other();
        }



        public void Player_Information()
        {
                PlayerWalk_Speed = 2.5f;
                PlayerRun_Speed = 4.0f;
                PlayerJump_Power = 240.0f;
                PlayerAttack_Damage = 30.0f;
                if(SceneManager.GetActiveScene().name == "2-2 Forest")
                {
                    PlayerWalk_Speed = 5f;
                    PlayerRun_Speed = 7f;
                }
        }


        public void MeleeEnemy_Information()
        {
                melee_EnemyWalk_Speed = 0.6f;
                melee_EnemyRun_Speed = 5f;

                if (SceneManager.GetActiveScene().name == "1-9 Train_City")
                {
                        melee_EnemyWalk_Speed = 4f;
                        melee_EnemyRun_Speed = 4f;
                        melee_Enemy_Detect_Distance = 80f;
                }
                melee_EnemyAttack_Damage = 12.0f;
                melee_Enemy_Detect_Distance = 1.5f;
                melee_EnemyAttack_Distance = 0.55f;
                defalt_detectPoint = 0.0f;
        }

        public void other()
        {
                Knock_Back_Power = 130.0f;
                Throw_Power = 80.0f;
                Up_detect = 10.0f;
                Down_detect = 0.5f;
                CCTV_Distance = 1.5f;
        }


        

}
