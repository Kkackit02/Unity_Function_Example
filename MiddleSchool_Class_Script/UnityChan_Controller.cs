using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChan_Controller : MonoBehaviour
{

        public float speed = 5.0f;
        Animator ani;
        public bool isWalk = false;
        public bool isRun = false;
        public float rotSpeed_X = 3.0f;

        public GameObject player;
    void Start()
    {
                ani = GetComponent<Animator>();
    }

    
    void Update()
    {

                //float MouseX = Input.GetAxis("Mouse X");
                //float MouseY = Input.GetAxis("Mouse Y");

                //transform.Rotate(Vector3.up * rotSpeed_X * MouseX);

                if (Input.GetKey(KeyCode.W))
                {
                        transform.Translate(Vector3.forward * speed * Time.deltaTime);
                        ani.SetFloat("Horizontal", 1);
                        
                }

                else if (Input.GetKey(KeyCode.S))
                {
                        transform.Translate(Vector3.back * speed * Time.deltaTime);
                        ani.SetFloat("Horizontal", -1);
                        
                }
                else
                {
                        ani.SetFloat("Horizontal", 0);
                        
                }

                if (Input.GetKey(KeyCode.A))
                {
                        transform.Translate(Vector3.left * speed * Time.deltaTime);
                        ani.SetFloat("Vertical", -1);
                        
                }
                else if (Input.GetKey(KeyCode.D))
                {
                        transform.Translate(Vector3.right * speed * Time.deltaTime);
                        ani.SetFloat("Vertical", 1);
                        
                }
                else
                {
                        ani.SetFloat("Vertical", 0);
                                
                }



                if (Input.GetKey(KeyCode.LeftShift))
                {
                        speed = 5.0f;
                        ani.SetBool("isRun", true);
                        isRun = true;
                }
                else
                {
                        speed = 2.0f;
                        ani.SetBool("isRun", false);
                        isRun = false;
                }
                




                




        }


        void OnTriggerEnter(Collider other)
        {
                if (other.tag == "Enemy")
                {
                        Destroy(player);

                        GameManager gameManager = FindObjectOfType<GameManager>();
                        gameManager.EndGame();
                }
        }
}
