using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{
        public float cameraSpeed = 15;

        public bool direction;
    void Start()
    {
                direction = false; //false 우측, true 좌측
    }

   
    void Update()
    {
                

                if(direction == false)
                {
                        transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);
                }

                else
                {
                        transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);
                }
    }

        private void OnTriggerEnter2D(Collider2D collision)
        {
                if (collision.tag == "CameraChange")
                {
                        if(direction == true)
                        {
                                direction = false;
                        }

                        else
                        {
                                direction = true;
                        }
                }
        }

}
