using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheak_Reflet : MonoBehaviour
{
        public GameObject RP;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


        public void OnTriggerStay2D(Collider2D collision)
        {
                if(collision.tag == "Water")
                {
                        RP.SetActive(false);
                }
        }
        public void OnTriggerExit2D(Collider2D collision)
        {
                if(collision.tag == "Water")
                {
                        RP.SetActive(true);
                }
        }
}
