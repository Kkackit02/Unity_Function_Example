using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
        public float rotation_Speed = 60.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                transform.Rotate(0f, rotation_Speed * Time.deltaTime, 0f);
    }
}
