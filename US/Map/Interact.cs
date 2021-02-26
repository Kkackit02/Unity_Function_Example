using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

        public int Type = 0;
        


        public GameObject Interact_Button;
        public GameObject Interact_Act;
        public GameObject Player;

        public GameObject NextScene_G;
        public NextScene NS;

        public GameObject PlayerCam;
        public GameObject FarCam;

        public GameObject Leser;


        private bool isclear = false;
        private Animator Player_Ani;
        private Player_Ctr Player_ctr;

        public bool isTalk = false;

        private bool isOut = true;


        public AudioSource AS;
        public AudioClip a;
        public AudioClip b;
        // Start is called before the first frame update
        void Start()
        {
                Player_Ani = Player.GetComponent<Animator>();
                Player_ctr = Player.GetComponent<Player_Ctr>();
                AS = GetComponent<AudioSource>();
                if(NextScene_G.gameObject == true)
                {
                        NS = NextScene_G.GetComponent<NextScene>();
                }
                
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
                        //Player_Ani.SetBool("Interact", false);

                }

        }

        public void OnClickBack()
        {
                isTalk = false;
                Player_Ani.SetBool("Interact", false);
                Invoke("invoke", 1.2f);
                AS.PlayOneShot(a);
                Player_Ani.SetTrigger("isCancle");
        }


        public void OnClick_Interact()
        {
                if(isOut == false && Type == 0)
                {
                        Player_Ani.SetTrigger("Interact_T");
                        isTalk = true;
                        Player_ctr.isMove = false;
                        AS.PlayOneShot(a);
                        
                }

        }

        public void Onclick_Next()
        {
                NS.NextS();
        }


        void invoke()
        {
                Player_ctr.isMove = true;
        }

        public void Take_Item()
        {
                Type = 1;
                AS.PlayOneShot(a);
        }


        public void isClear()
        {
                Player_Ani.SetBool("Interact", false);
                Player_Ani.SetTrigger("isCancle");
                PlayerCam.SetActive(false);
                FarCam.SetActive(true);
                Interact_Button.SetActive(false);
                Invoke("OFFLESER", 3f);
                isclear = true;
                AS.PlayOneShot(a);
        }

        void OFFLESER()
        {
                Leser.SetActive(false);
                Invoke("End", 1f);
                AS.PlayOneShot(b);
                Invoke("invoke", 1.3f);
        }

        void End()
        {
                Player_Ani.SetTrigger("isCancle");
                PlayerCam.SetActive(true);
                FarCam.SetActive(false);
                Player_Ani.SetBool("Interact", false);

        }

}
