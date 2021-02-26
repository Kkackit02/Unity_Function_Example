using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        void OnTriggerEnter(Collider other)
        {

                if (other.tag == "Player")
                {
                        PlayerController playerController = other.GetComponent<PlayerController>();

                        if (playerController != null)
                        {
                                playerController.Die();
                        }


                }
        }
}
