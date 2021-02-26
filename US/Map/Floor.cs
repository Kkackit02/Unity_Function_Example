using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
        public GameObject Interact_Button;

        public GameObject PlayerCamera;
        public GameObject ElevetorCamera;



        public GameObject button_screen;
        public bool isOut = true;
        public bool isTalk = false;




        
        // Start is called before the first frame update
        void Start()
    {
                PlayerCamera = GameObject.Find("PlayerCam");
                ElevetorCamera = GameObject.Find("EleveterCam");


        }

    // Update is called once per frame
    void Update()
    {
                
                
        }

        public void OnClick_Interact()
        {

                if (isOut == false)
                {
                        isTalk = true;
                        button_screen.SetActive(true);
                        PlayerCamera.SetActive(false);
                        //ElevetorCamera.SetActive(true);

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
                
                if (collision.gameObject.tag == "Player")
                {
                        isTalk = false;
                        Interact_Button.SetActive(false);
                        button_screen.SetActive(false);
                        PlayerCamera.SetActive(true);
                        //ElevetorCamera.SetActive(false);


                        isOut = true;
                        
                }

        }



        

}
