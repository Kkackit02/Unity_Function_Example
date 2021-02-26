using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock_Door : MonoBehaviour
{


        public int Cheak;
        public GameObject Interact_Button;
        //public GameObject Interact_Act;

        public GameObject Wall;
        public bool isTalk = false;

        public BoxCollider2D BC;

        public Animator ani;

        public bool isOpen;


        private bool isOut = true;
        public AudioSource AS;
        public AudioClip a;
        public AudioClip b;

        // Start is called before the first frame update
        void Start()
        {
                AS = GetComponent<AudioSource>();
                isOpen = false;
                BC = Wall.GetComponent<BoxCollider2D>();
                BC.enabled = true;
                ani = GetComponent<Animator>();

              

        }

        // Update is called once per frame
        void Update()
        {
                

                if (isTalk == true)
                {
                        Interact_Button.SetActive(false);
                        //Interact_Act.SetActive(true);
                }
                else
                {

                        //Interact_Act.SetActive(false);
                }
        }

        void OnTriggerStay2D(Collider2D collision)
        {

                if (collision.gameObject.tag == "Player")
                {
                        Interact_Button.SetActive(true);
                        //Cheak = GameObject.Find("Player_M").GetComponent<Interact_Button>().cheak_N;

                        isOut = false;
                                
                                //isTalk = true;   계속 열고닫게 하기위해 일단 주석처리
                                //BC.enabled = false;
                                //ani.SetBool("Isopen",true);
                                
                }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
                Interact_Button.SetActive(false);
                if (collision.gameObject.tag == "Player")
                {
                        isTalk = false;
                        isOut = true;
                        //ani.SetBool("Isopen",false);
                        
                }

        }


        public void OnClick_Interact()
        {
                if (isOut == false)
                {
                        if (isOpen == true)
                        {
                                ani.SetBool("isOpen", false);
                                isOpen = false;
                                BC.enabled = true;
                                AS.PlayOneShot(b);
                        }

                        else if (isOpen == false)
                        {
                                ani.SetBool("isOpen", true);
                                isOpen = true;
                                BC.enabled = false;
                                AS.PlayOneShot(a);
                        }
                }
                
        }

}
