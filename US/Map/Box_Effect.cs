using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Effect : MonoBehaviour
{
        public Rigidbody2D rd;
        public float time = 0;
    void Start()
    {
                rd = GetComponent<Rigidbody2D>();

                time = 0;
                rd.AddForce(new Vector3(Random.Range(-2, 2), Random.Range(1, 3), 0), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
                time = time + Time.deltaTime;
                if(time > 4)
                {
                        Destroy(this.gameObject);
                }
    }
}
