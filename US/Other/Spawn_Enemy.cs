using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemy : MonoBehaviour
{
        public GameObject Enemy_One;
        public GameObject Enemy_Two;
        public GameObject Enemy_Three;
        public GameObject Enemy_Four;
        public GameObject Enemy_Five;
        public GameObject SpawnPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Onclick_EnemySpawn()
        {
                Enemy_One.SetActive(true);
                Enemy_Two.SetActive(true);
                Enemy_Three.SetActive(true);
                Enemy_Four.SetActive(true);
                Enemy_Five.SetActive(true);
        }
}
