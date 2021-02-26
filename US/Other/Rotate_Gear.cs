using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Gear : MonoBehaviour
{
        public int type = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                if (type == 0)
                {
                        transform.Rotate(0, 0, 5);
                }
                
                else
                {
                        transform.Rotate(0, 0, -5);
                }
    }
}
