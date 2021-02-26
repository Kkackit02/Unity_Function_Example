using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

        public float time;
        public float speed = 8.0f;
    void Start()
    {
                
                
                
        }

    // Update is called once per frame
    void Update()
    {
                time =+ Time.deltaTime;
                transform.Translate(Vector3.forward * speed * Time.deltaTime);


                if (time == 3.0f)
                {
                        Destroy(this);
                }
        }
        

        
}
