using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break_Box : MonoBehaviour
{
        public GameObject brokenBox;


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


        public void OnTriggerEnter2D(Collider2D collision)
        {
                if(collision.tag == "Player_Attack")
                {
                        Instantiate(brokenBox, this.gameObject.transform.position, this.gameObject.transform.rotation);
                        Destroy(this.gameObject);
                }

                if (collision.tag == "Enemy_Attack")
                {
                        Instantiate(brokenBox, this.gameObject.transform.position, this.gameObject.transform.rotation);
                        Destroy(this.gameObject);
                }

        }
}
