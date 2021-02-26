using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTV : MonoBehaviour
{
        public Vector2 EnemyPosition;
        private float MaxDistance = 15.0f;
        public float detectPoint;

        public Vector2 leserPoint;

        public DataManager datamanager;
        private float Up_Detect;
        private float Down_Detect;

        private float Rotation_Change;
        private float Rotation_Max;
        private float cheak_Rotation = 0;
        private float Rotation_Time;

        public bool isdie = false;

        public bool isCCTv = true;
        public GameObject CCTV_View;

        int layerMask = 1 << 8;

        public GameObject Break_CCTV;
        public GameObject Remain_CCTV;

        public AudioSource AS;
        public AudioClip a;
        RaycastHit2D hit;
        public int type = 0;
        public GameObject Drone;
        //public Transform Drone_Spawn;
        public bool isSpawn = false;
        void Start()
        {
                AS = GetComponent<AudioSource>();

                datamanager = GameObject.Find("DataManager").GetComponent<DataManager>();
                detectPoint = datamanager.defalt_detectPoint;
                Up_Detect = datamanager.Up_detect;
                Down_Detect = datamanager.Down_detect;
                MaxDistance = datamanager.CCTV_Distance;

                Rotation_Time = 0;
                
        }


    // Update is called once per frame
    void Update()
    {

                if(isSpawn == false)
                {
                        if(detectPoint > 95)
                        {
                                isSpawn = true;
                                Drone.SetActive(true);
                        }
                        
                }

                if (isCCTv == true)
                {
                        if (isdie == false)
                        {
                                if (type == 0)
                                {
                                        Rotation_Time += Time.deltaTime;
                                        if (Rotation_Time <= 5)
                                        {
                                                cheak_Rotation += Time.deltaTime * 5;
                                                transform.rotation = Quaternion.Euler(0, 0, cheak_Rotation + 200);

                                        }
                                        else if (Rotation_Time > 5)
                                        {
                                                cheak_Rotation -= Time.deltaTime * 5;
                                                transform.rotation = Quaternion.Euler(0, 0, cheak_Rotation + 200);
                                        }
                                        if (Rotation_Time > 10)
                                        {
                                                cheak_Rotation = 0;
                                                Rotation_Time = 0;
                                        }
                                }
                                else
                                {
                                        Rotation_Time += Time.deltaTime;
                                        if (Rotation_Time <= 5)
                                        {
                                                cheak_Rotation += Time.deltaTime * 5;
                                                transform.rotation = Quaternion.Euler(0, 0, cheak_Rotation - 60);

                                        }
                                        else if (Rotation_Time > 5)
                                        {
                                                cheak_Rotation -= Time.deltaTime * 5;
                                                transform.rotation = Quaternion.Euler(0, 0, cheak_Rotation - 60);
                                        }
                                        if (Rotation_Time > 10)
                                        {
                                                cheak_Rotation = 0;
                                                Rotation_Time = 0;
                                        }
                                }
                        }




                        



                        EnemyPosition = this.gameObject.transform.position;
                        if (isdie == false)
                        {
                                hit = Physics2D.Raycast(EnemyPosition, transform.right, MaxDistance, layerMask);
                                Debug.DrawRay(EnemyPosition, transform.right * 2, Color.red, 0.3f);
                        }

                        //물체기준 왼쪽으로 레이를 발사하는법?




                


                        if (hit.collider != null)
                        {
                                //Debug.Log("CCTV 레이 인식");
                                string name = hit.collider.gameObject.name;
                                Debug.Log(name);
                                if (name.Equals("Player_M"))
                                {
                                        //Debug.Log("발각!");
                                        detectPoint += (Up_Detect);
                                }
                                else
                                {
                                        detectPoint -= (Down_Detect);
                                }
                        }

                        else
                        {
                                detectPoint -= (Down_Detect * Time.deltaTime);
                        }



                        if (detectPoint + Up_Detect >= 100.0f)
                        {
                                detectPoint = 100.0f;
                        }

                        if (detectPoint - Down_Detect < 0.0f)
                        {
                                detectPoint = 0.0f;
                        }
                }

                else if (isdie == true)
                {
                        
                        //애니메이션
                }

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
                if (collision.tag == "Throw_Thing")
                {

                        if(isdie == false)
                        {
                                AS.PlayOneShot(a);
                                Remain_CCTV.SetActive(true);
                                Break_CCTV.SetActive(true);
                                CCTV_View.SetActive(false);
                                GetComponent<SpriteRenderer>().enabled = false;
                                isdie = true;
                        }
                        
                }
        }
}

