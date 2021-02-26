using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheak_JoyStickPosition : MonoBehaviour
{

        public float Horizontal;
        public float Vertical;
        public bool isRun = false;
    void Start()
    {
                Horizontal = 0;
    }

    // Update is called once per frame
    

        public void OnTriggerStay2D(Collider2D other)
        {

                {

                        //Debug.Log("조이스틱 인식중");
                        /*
                        if (other.gameObject.tag == "Up")
                        {
                                Vertical = 1;
                        }
                        */
                        
                        if (other.gameObject.tag == "Right")
                        {
                                Horizontal = 1;
                        }
                        else if (other.gameObject.tag == "Left")
                        {
                                Horizontal = -1;
                        }

                        if (other.gameObject.tag == "Run_Cheak")
                        {
                                isRun = true;
                        }

                }
        }

        public void OnTriggerExit2D(Collider2D other)
        {

                {

                        //Debug.Log("조이스틱 인식중");
                        /*
                        if (other.gameObject.tag == "Up")
                        {
                                Vertical = 0;
                        }
                        */


                        if (other.gameObject.tag == "Right")
                        {
                                Horizontal = 0;
                        }
                        else if (other.gameObject.tag == "Left")
                        {
                                Horizontal = 0;
                        }
                        else
                        {
                                Horizontal = 0;
                                Vertical = 0;
                        }

                        if (other.gameObject.tag == "Run_Cheak")
                        {
                                isRun = false;
                        }
                }
        }






}
