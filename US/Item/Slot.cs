using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
        public int number;
        public Item item;
        public Text Explain;
        public GameObject E;
        public GameObject Use;
        public GameObject Throw;
        public GameObject Heal;

        public void Start()
        {
                
                E = GameObject.Find("Bag_Explain");
                Explain = GameObject.Find("Bag_Explain").transform.Find("Name").GetComponent<Text>();
                Throw = GameObject.Find("ThrowCTR");
                Heal = GameObject.Find("Heal");

               

        }
        // Update is called once per frame
        void Update()
        {
                if (Throw.gameObject == true)
                {
                        if (item.itemName == "Bottle" && item.itemCount <= 0)
                        {
                                Throw.SetActive(false);
                        }
                        else if (item.itemName == "Bottle" && item.itemCount > 0)
                        {
                                Throw.SetActive(true);
                        }

                }

                if (Heal.gameObject == true)
                {
                        if (item.itemName == "Heal" && item.itemCount <= 0)
                        {
                                Heal.SetActive(false);
                        }
                        else if (item.itemName == "Heal" && item.itemCount > 0)
                        {
                                Heal.SetActive(true);
                        }
                }
                       

        }



        public void Onclick_Bring()
        {
                E.transform.position = new Vector3(950, 600, 0);
                Explain.text = item.Explanation;
        }

        public void Onclick_Out()
        {
                E.transform.position = new Vector3(800, 10000, 0);
        }

        /*
        public void Onclick_Use()
        {
                if(item.itemName == "Bottle")
                {
                        Throw.SetActive(true);
                }
        }
        */
}
