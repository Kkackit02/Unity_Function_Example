using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train_Background : MonoBehaviour
{
        public float speed = 15f;
        public Transform Start_Tr;
        public GameObject Back_Tr;
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
                transform.Translate(Vector3.left * speed * Time.deltaTime);

                if(transform.position.x < -200)
                {
                       transform.position = Back_Tr.transform.position;
                }

    }


}
