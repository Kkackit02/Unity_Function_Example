using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

        public Text textDisplay;
        public string[] sentences;
        public int index;
        public float typingSpeed;

        public Menu menu;
        public bool isdialog;

        public bool istalk_Dialog;
        public bool isOut_Dialog;

        public GameObject Npc_Text;
        public GameObject Menu;
        public GameObject NextScene;





        void Start()
        {
                StartCoroutine(Type());
                index = -1;
                menu = Menu.GetComponent<Menu>();
        }


        IEnumerator Type()
        {
                foreach(char letter in sentences[index].ToCharArray())
                {
                        textDisplay.text += letter;
                        yield return new WaitForSeconds(typingSpeed);
                }


                
        }
        


        public void NextSentence()
        {

               // Debug.Log("Next Sentence!");

                //isdialog = true;
                if (isdialog == false)
                {
                        //Debug.Log("N3!");
                        if (index < sentences.Length - 1)
                        {

                                textDisplay.text = "";

                                index++;
                                StartCoroutine(Type());



                        }

                        else
                        {
                                textDisplay.text = "대화종료";
                                Npc_Text.SetActive(false);

                                if (isOut_Dialog == true)
                                {

                                        index = -1;
                                        isdialog = false;

                                }






                        }

                        if (index == sentences.Length - 1)
                        {
                                //
                                if (SceneManager.GetActiveScene().name == "3-1 revolution")
                                {
                                        SceneManager.LoadScene("3-2 revolution");
                                }
                                else if (SceneManager.GetActiveScene().name == "3-1 Excape")
                                {
                                        SceneManager.LoadScene("3-2 Excape");
                                }
                                else if (SceneManager.GetActiveScene().name == "3-2 Excape")
                                {
                                        SceneManager.LoadScene("3-3 End_ex");
                                }
                                else if (SceneManager.GetActiveScene().name == "3-2 revolution")
                                {
                                        SceneManager.LoadScene("3-3 End_rev");
                                }
                                else if (SceneManager.GetActiveScene().name == "3-3 End_ex")
                                {
                                        SceneManager.LoadScene("MainMenu");
                                }
                                else if (SceneManager.GetActiveScene().name == "3-3 End_rev")
                                {
                                        SceneManager.LoadScene("MainMenu");
                                }

                                else
                                {
                                        menu.OnClickNextBtn();
                                }
                                
                        }
                }
                

        

                /*
                if(index < sentences.Length-1)
                {
                        
                        textDisplay.text = "";
                        textDisplay.text = sentences[index];
                        index = index + 1;
                        isdialog = false;

                        

                }

                else
                {
                        textDisplay.text = "";
                }
                */
                
        }



        void Update()
        {

                

               




                if (index >= 0)
                {
                        if (textDisplay.text == sentences[index])
                        {
                                isdialog = false;
                        }

                        else if (textDisplay.text != sentences[index])
                        {

                                isdialog = true;
                        }
                }







        }

        


}
