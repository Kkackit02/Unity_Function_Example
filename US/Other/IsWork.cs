using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsWork : MonoBehaviour
{
        public BoxCollider2D BC;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


        public void OnclickWork()
        {
                BC.enabled = false;
                GetComponent<NPC>().enabled = false;
        }
}
