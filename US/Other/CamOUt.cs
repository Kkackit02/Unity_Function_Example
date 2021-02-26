using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CamOUt : MonoBehaviour
{
        public GameObject PC;
        public GameObject EC;
        public GameObject OC;
        public GameObject Player;
        public bool isClick = false;

        void Start()
        {
                if (SceneManager.GetActiveScene().name == "2-6 AttackedBunker")
                {
                        Invoke("Start_E", 0.3f);
                }
        }

        // Update is called once per frame
        void Update()
        {

        }
        void Start_E()
        {
                OnEvent();
        }
        public void OnEvent()
        {
                PC.SetActive(false);
                Invoke("OnInvoke", 2.5f);
                Player.GetComponent<Player_Ctr>().enabled = false;
        }


        public void OnInvoke()
        {
                PC.SetActive(true);
                Player.GetComponent<Player_Ctr>().enabled = true;
        }

        public void OnTriggerStay2D(Collider2D collision)
        {
                if (collision.transform.tag == "Player")
                {
                        if(isClick == false)
                        {
                                PC.SetActive(false);
                                EC.SetActive(false);
                                OC.SetActive(true);
                        }
                        
                }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
                if (collision.tag == "Player")
                {
                        if(isClick == false)
                        {
                                PC.SetActive(true);
                                EC.SetActive(true);
                                OC.SetActive(false);
                        }
                       
                }
        }


        public void onClick()
        {
                if(isClick == false)
                {
                        isClick = true;
                        PC.SetActive(false);
                }
                else
                {
                        isClick = false;
                        PC.SetActive(true);
                }
                
        }
}
