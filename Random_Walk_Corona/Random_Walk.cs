using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Walk : MonoBehaviour
{
    public int random_value;

    public int up_W;
    public int down_W;
    public int left_W;
    public int right_W;

    public Rigidbody rd;
    public float speed = 1f;

    void Start()
    {
        //rd = gameObject.GetComponent<Rigidbody>();
 
        transform.rotation = Quaternion.Euler(Random.Range(-25f, 15f), - 90f + Random.Range(-25f, 25f), Random.Range(-25f,15f));
        Force();
    }



    public void Force()
    {
        rd.AddForce(transform.forward * 30000);
    }

    public void Moving()
    {
        random_value = Random.Range(0, 4);

        //0.4가 정석
        if (random_value == 0)
        {
            transform.Translate(speed * Time.timeScale, 0, 0);
        }
        else if (random_value == 1)
        {
            transform.Translate(-speed * Time.timeScale, 0, 0);
        }
        else if (random_value == 2)
        {
            transform.Translate(0, 0, speed * Time.timeScale);

        }
        else if (random_value == 3)
        {
            transform.Translate(0, 0, -speed * Time.timeScale);
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Table")
        {
            speed = 0;
            rd.velocity = new Vector3(0, 0, 0);
            Destroy(GetComponent<Rigidbody>());

        }

        else if (other.CompareTag("Floor"))
        {
            speed = 0;
            Destroy(GetComponent<Rigidbody>());
        }

        

    }
}

