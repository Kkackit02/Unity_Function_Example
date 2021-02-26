using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
        public GameObject Object;
        public GameObject Right_ThrowPoint;
        public GameObject Left_ThrowPoint;
        private SpriteRenderer SpriteRenderer;
        private Rigidbody2D rb;
        private float Throw_Power;
        private DataManager datamanager;

        void Start()
    {

                datamanager = GameObject.Find("DataManager").GetComponent<DataManager>();
                SpriteRenderer = GetComponent<SpriteRenderer>();
                Throw_Power = datamanager.Throw_Power;
        }

    // Update is called once per frame
     

        public void OnClickThrow()
        {
                if (SpriteRenderer.flipX == true)
                {
                        GameObject Thing = Instantiate(Object, Left_ThrowPoint.transform.position, Left_ThrowPoint.transform.rotation);

                        rb = Thing.gameObject.GetComponent<Rigidbody2D>();

                        rb.AddForce(Vector2.left * Throw_Power * Time.deltaTime);
                        rb.AddForce(Vector2.up * Throw_Power * Time.deltaTime);
                }

                if (SpriteRenderer.flipX == false)
                {
                        
                        GameObject Thing = Instantiate(Object, Right_ThrowPoint.transform.position, Right_ThrowPoint.transform.rotation);
                        rb = Thing.gameObject.GetComponent<Rigidbody2D>();

                        rb.AddForce(Vector2.right * Throw_Power * Time.deltaTime);
                        rb.AddForce(Vector2.up * Throw_Power * Time.deltaTime);
                }
        }
}
