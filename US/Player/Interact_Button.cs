using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Button : MonoBehaviour
{
        float count = 0;
        public CapsuleCollider2D Player_Collider;
        
        public int state = 0;

        public int cheak_N = 0;
    void Start()
    {
                Player_Collider = GameObject.Find("Player_M").GetComponent<CapsuleCollider2D>();
                GameObject[] door = GameObject.FindGameObjectsWithTag("Door");
                GameObject[] npc = GameObject.FindGameObjectsWithTag("NPC");
                GameObject[] elevetor = GameObject.FindGameObjectsWithTag("Elevetor");
                GameObject[] interact = GameObject.FindGameObjectsWithTag("Observe");



        }

    // Update is called once per frame
    void LateUpdate()
    {
                

        }

        public void OnTriggerStay2D(Collider2D Player_Collider)
        {
                switch (Player_Collider.gameObject.tag)
                {
                        case "Door":

                                state = 1;
                                break;
                        case "NPC":

                                state = 2;
                                break;
                        case "Observe":
                                state = 3;
                                break;
                        case "elevetor":
                                state = 4;
                                break;

                        default:
                                //state = 0;
                                break;

                }

        }

        public void OnclickButton()
        {
                if (state == 1)
                {
                        cheak_N = 1;

                }
                else if (state == 2)
                {
                        cheak_N = 2;
                }
                else if (state == 3)
                {
                        cheak_N = 3;
                }
                else if (state == 4)
                {
                        cheak_N = 4;
                }
                else
                {
                        cheak_N = 0;
                }

                
                
        }

}
