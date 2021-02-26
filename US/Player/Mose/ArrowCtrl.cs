using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCtrl : MonoBehaviour
{

        public GameObject Player_Point;
    public Vector3 player;
    // Update is called once per frame
    void Update()
    {
                player = Player_Point.transform.position;
        if (Global.IsArrowShow)
        {
            //print("On");
            //This.gameObject.SetActive(true);
            transform.rotation = Quaternion.identity;
            transform.position = new Vector3(player.x, player.y, 5);
            transform.Rotate(0, 0 , Global.ArrowAngle * -1 + 90);
        }
        else
        {
            //print("Off");
            //This.gameObject.SetActive(false);
            transform.position = new Vector3(0, 0, -15);
        }
    }
}
