using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_E : MonoBehaviour
{

        public int Type = 0;
        


        public GameObject Interact_Button;
        public GameObject Interact_Act;
        public GameObject OpenCamera;
        public GameObject PlayerCamera;
        public GameObject Fog;

        public GameObject one;
        public GameObject two;
        public GameObject three;
        public GameObject Four;
        public bool CCTV_A = true;

        public bool isclear = false;

        public AudioSource AS;
        public AudioClip a;
        public AudioClip b;


        public bool isTalk = false;

        private bool isOut = true;
        // Start is called before the first frame update
        void Start()
        {
                AS = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
                if (isTalk == true)
                {
                        Interact_Button.SetActive(false);
                        if(isclear == false)
                        {
                                Interact_Act.SetActive(true);
                        }
                        else
                        {
                                Interact_Act.SetActive(false);
                        }
                }
                else
                {

                        Interact_Act.SetActive(false);
                }
        }

        void OnTriggerStay2D(Collider2D collision)
        {

                if (collision.gameObject.tag == "Player")
                {
                        Interact_Button.SetActive(true);


                        isOut = false;





                }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
                Interact_Button.SetActive(false);
                if (collision.gameObject.tag == "Player")
                {
                        isTalk = false;
                        isOut = true;

                }

        }

        public void OnClickBack()
        {
                isTalk = false;
                AS.PlayOneShot(a);
                Invoke("Invoke", 1.05f);
                
        }


        public void OnClick_Interact()
        {
                if(isOut == false)
                {
                        AS.PlayOneShot(a);
                        isTalk = true;
                        
                        
                }

        }


        

        public void invoke()
        {
                AS.PlayOneShot(a);
                PlayerCamera.SetActive(false);
                //OpenCamera.SetActive(true);
                Fog.SetActive(true);
                one.SetActive(false);
                two.SetActive(false);
                three.SetActive(false);
                Four.SetActive(false);
                one.GetComponent<CCTV>().isdie = true;
                two.GetComponent<CCTV>().isdie = true;
                three.GetComponent<CCTV>().isdie = true;
                Four.GetComponent<CCTV>().isdie = true;
                isclear = true;
                Invoke("invoke2", 4f);
        }

        void invoke2()
        {
                PlayerCamera.SetActive(true);
                //OpenCamera.SetActive(false);
        }

        public void Take_Item()
        {
                Type = 1;
        }

}
