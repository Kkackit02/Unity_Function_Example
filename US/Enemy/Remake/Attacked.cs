using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacked : MonoBehaviour
{


        public Collider2D BC_L;

        public Collider2D BC_R;
        public Enemy enemy;
    void Start()
    {

                //BC = GetComponent<BoxCollider2D>();
                enemy = gameObject.transform.parent.GetComponent<Enemy>();   
                


    }

    // Update is called once per frame
    void Update()
    {
        
                if (enemy.dist == "Right")
                {

                        BC_L.enabled = true;
                        BC_R.enabled = false;
                }
                else if (enemy.dist == "Left")
                {

                        BC_L.enabled = false;
                        BC_R.enabled = true; 
                }

    }

        private void OnTriggerEnter2D(Collider2D collision)
        {
                if (collision.gameObject.tag == "Player_Attack")
                {
                        //Debug.Log("충돌 체크3");
                        enemy.enemy_Die = true;

                        BC_L.enabled = false;
                        BC_R.enabled = false;
                }
        }
}
