using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour
{
        public GameObject Player_M;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


        public void OnTriggerEnter2D(Collider2D collision)
        {
                if(collision.tag == "Player")
                {
                        Player_M.GetComponent<Rigidbody2D>().gravityScale = 0;
                }
                
        }
        public void OnTriggerExit2D(Collider2D collision)
        {
                if (collision.tag == "Player")
                {
                        Player_M.GetComponent<Rigidbody2D>().gravityScale = 1.4f;
                }
        }

}
