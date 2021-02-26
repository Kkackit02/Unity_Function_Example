using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagTransform : MonoBehaviour
{
        

        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void Onclick_Bring()
        {
                transform.position = new Vector3(950, 600, 0);
                
        }

        public void Onclick_Out()
        {
                transform.position = new Vector3(800, 10000, 0);
        }
}
