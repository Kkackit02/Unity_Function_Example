using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Time_controller : MonoBehaviour
{
    public Text Time_Text;
    public Text Contect_Text;
    public int contect_corona = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Time.timeScale += 0.01f;

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Time.timeScale -= 0.01f;
        }

        Time_Text.text = Time.timeScale.ToString();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Corona"))
        {
            //other.gameObject.GetComponent<Random_Walk>().speed = 0;
            //Destroy(other.gameObject.GetComponent<Rigidbody>());

            contect_corona += 1;
            Contect_Text.text = contect_corona.ToString();
        }



    }
}
