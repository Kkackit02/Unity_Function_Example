using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Lock : MonoBehaviour
{
        public string Key = "43125";
        public string input = "";
        public Text text;

        public GameObject Th;
        public bool isClear = false;
        public Interact I;
        public GameObject NScene;
        void Start()
    {
        
    }

    // Update is called once per frame
    
        public void One()
        {
                input += "1";
                text.text = input;
        }
        public void Two()
        {
                input += "2";
                text.text = input;
        }
        public void Three()
        {
                input += "3";
                text.text = input;
        }
        public void Four()
        {
                input += "4";
                text.text = input;

        }
        public void Five()
        {
                input += "5";
                text.text = input;
        }

        public void Six()
        {
                input += "6";
                text.text = input;
        }
        public void Seven()
        {
                input += "7";
                text.text = input;

        }
        public void Eight()
        {
                input += "8";
                text.text = input;
        }

        public void Nine()
        {
                input += "9";
                text.text = input;
        }
        public void Zero()
        {
                input += "0";
                text.text = input;

        }
      


        public void Reset()
        {
                input = "";
                text.text = input;
        }
        public void Cheak()
        {
                if(input == Key)
                {

                        isClear = true;
                        input = "";

                        

                        if (SceneManager.GetActiveScene().name == "2-2 Forest")
                        {
                                NScene.GetComponent<NextScene>().NextS();
                        }
                        else
                        {
                                I.isClear();
                        }
                        //text.text = "승인";


                }
                else
                {
                        text.text = "";
                        input = "";

                }
        }


}
