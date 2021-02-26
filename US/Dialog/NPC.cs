using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NPC : MonoBehaviour
{
        public GameObject NPC_CHAT;

        public int count;
        public Text textDisplay;
        public string[] sentences;
        public int index;
        public float typingSpeed;


        public BoxCollider2D BC;
        public bool isdialog = false;
        public bool istalk = false;
        public bool isOut = true;
        public GameObject Interact_Button;

        public GameObject NScene;

        public GameObject Inven;
        void Start()
        {
                StartCoroutine(Type());
                index = -1;

        }

        IEnumerator Type()
        {

                foreach (char letter in sentences[index].ToCharArray())
                {
                        textDisplay.text += letter;
                        yield return new WaitForSeconds(typingSpeed);
                }


        }

        void Update()
        {




                if (istalk == true)
                {
                        Interact_Button.SetActive(false);

                }

                else if (istalk == false)
                {
                        textDisplay.text = "";
                        index = -1;

                }

                
                if (index >= 0)
                {
                        if (textDisplay.text == sentences[index])
                        {
                                isdialog = false;
                        }

                        else if (istalk == true && textDisplay.text != sentences[index])
                        {


                                isdialog = true;
                        }
                }

                if (index == sentences.Length - 1)
                {
                        if(count == 0)
                        {
                                if (SceneManager.GetActiveScene().name == "2-6 AttackedBunker")
                                {
                                        Inven.GetComponent<Inventory>().AddDuru();
                                        count = 1;
                                }
                        }
                        
                        NScene.GetComponent<NextScene>().NextS();
                }

        }




        public void NextSentence()
        {

                Debug.Log("Next Sentence!");

                isdialog = false;
                if (index < sentences.Length-1)
                {

                        textDisplay.text = "";
                       
                                index++;
                                StartCoroutine(Type());
                        


                }

                else
                {
                        textDisplay.text = "";

                        
                        //NPC_CHAT.SetActive(false);

                        if (isOut == true)
                        {

                                index = -1;
                                isdialog = false;

                        }
                }


        }

        public void OnClick_Interact()
        {
                if (isOut == false)
                {
                        NPC_CHAT.gameObject.SetActive(true);
                        istalk = true;


                        if (isdialog == false)
                        {
                                NextSentence();
                                isdialog = true;
                        }
                }
                
        }


        public void OnClick_Work()
        {
                BC.enabled = false;
                Destroy(NPC_CHAT);
                Destroy(Interact_Button);

                

        }
        void OnTriggerStay2D(Collider2D collision)

        {

                if (collision.gameObject.tag == "Player")
                {
                        isOut = false;

                        if (istalk == false)
                        {
                                Interact_Button.SetActive(true);
                        }
                        
                        /*
                        if (isdialog_NPC == false )
                        {
                                if (Input.GetKeyDown(KeyCode.Space) && istalk == true)
                                {
                                        GameObject.Find("Dialogue Manager").GetComponent<DialogueManager>().NextSentence();
                                }
                        }
                        */

                
                }



        }


        void OnTriggerExit2D(Collider2D collision)

        {

                if (collision.gameObject.tag == "Player")
                {

                        //Debug.Log("ExitNPC");
                        NPC_CHAT.gameObject.SetActive(false);
                        istalk = false;
                        isdialog = false;
                        isOut = true;
                }


                Interact_Button.SetActive(false);


        }
}



