using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevetor_Screen : MonoBehaviour
{
        public GameObject Player;
        public GameObject Goal_Point;
        public List<GameObject> floor = new List<GameObject>();
        public bool isOut = true;
        public bool isTalk = false;
        public AudioSource AS;
        public AudioClip a;
        // Start is called before the first frame update
        void Start()
    {
               
                Player = GameObject.Find("Player_M");
                AS = GetComponent<AudioSource>();

                AS.clip = a;
        }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void onclick_1()
        {
                AS.Play();
                Goal_Point = floor[0];
                        Player.transform.position = Goal_Point.transform.position;
                        
        }

        public void onclick_2()
        {
                AS.Play();
                Goal_Point = floor[1];
                        Player.transform.position = Goal_Point.transform.position;
               
        }

        public void onclick_3()
        {
                AS.Play();
                Goal_Point = floor[2];
                        Player.transform.position = Goal_Point.transform.position;
              
        }
        public void onclick_4()
        {
                AS.Play();
                Goal_Point = floor[3];
                Player.transform.position = Goal_Point.transform.position;
                
        }
        public void onclick_5()
        {
                AS.Play();
                Goal_Point = floor[4];
                Player.transform.position = Goal_Point.transform.position;
                
        }
        public void onclick_6()
        {
                AS.Play();
                Goal_Point = floor[5];
                Player.transform.position = Goal_Point.transform.position;
                
        }
}
