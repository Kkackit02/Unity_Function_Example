using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
        public int stage = 3;
        public float speed = 5.0f;
        public bool isWalk = true;
        public string itemName = "라바돈의 뿅뿅모자";
        



    void Start()
    {
                


        }

    // Update is called once per frame
    void Update()
    {
                Debug.Log("stage" + stage);
                Debug.Log("speed" + speed);
                Debug.Log("iswalk" + isWalk);
                Debug.Log("itemName" + itemName);
        }
}
