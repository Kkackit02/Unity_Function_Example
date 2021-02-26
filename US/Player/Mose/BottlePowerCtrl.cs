using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottlePowerCtrl : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public float power;
        public GameObject Broken;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d.velocity = new Vector2(Global.PowerX * Global.BottlePower, Global.PowerY * Global.BottlePower );
        rigidbody2d.AddTorque(power * power / 4);
    }

        private void Update()
        {
                
        }




        public void OnTriggerEnter2D(Collider2D collision)
        {
                if(collision.gameObject.tag == "Ground" )
                {
                        //this.gameObject.GetComponent<SpriteRenderer>().sprite = Broken;
                        Instantiate(Broken, this.gameObject.transform.position, this.gameObject.transform.rotation);
                        Destroy(this.gameObject);


                }

                if(collision.gameObject.tag == "Wall")
                {
                        Instantiate(Broken, this.gameObject.transform.position, this.gameObject.transform.rotation);
                        Destroy(this.gameObject);
                }
        }
}
