using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

        private Rigidbody playerRigidody;
        public float speed = 2.0f;


    void Start()
    {
                playerRigidody = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {



                if (Input.GetKey(KeyCode.W) == true)
                {
                        transform.Translate(Vector3.forward * speed * Time.deltaTime);

                }
                if (Input.GetKey(KeyCode.S) == true)
                {
                        transform.Translate(Vector3.back * speed * Time.deltaTime);

                }
                if (Input.GetKey(KeyCode.A) == true)
                {
                        transform.Translate(Vector3.left * speed * Time.deltaTime);

                }
                if (Input.GetKey(KeyCode.D) == true)
                {
                        transform.Translate(Vector3.right * speed * Time.deltaTime);

                }



        }



     public void Die()
        {
                gameObject.SetActive(false);

                GameManager gameManager = FindObjectOfType<GameManager>();

                gameManager.EndGame();
        }
}
