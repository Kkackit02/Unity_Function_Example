using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstain : MonoBehaviour
{
        public GameObject Player;
        public PlayerHealth playerhealth;
        public Player_Ctr player_ctr;
        
    // Start is called before the first frame update
    void Start()
    {
                Player = GameObject.Find("Player_M");
                playerhealth = GameObject.Find("PlayerHealth").GetComponent<PlayerHealth>();
                player_ctr = GameObject.Find("Player_M").GetComponent<Player_Ctr>();
                
        }

    // Update is called once per frame
    void Update()
    {
        
    }

        private void OnTriggerEnter2D(Collider2D collision)
        {
                if (collision.tag == "Player")
                {
                        string dist = "";

                        if(this.gameObject.transform.position.x > Player.transform.position.x )
                        {
                                dist = "right";
                        }
                        else
                        {
                                dist = "left";
                        }
                        playerhealth.OnDamage(15);
                        player_ctr.KnockBack(dist);



                }
        }

}
