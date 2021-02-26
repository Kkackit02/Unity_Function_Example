using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class If_Cheak : MonoBehaviour
{
        int CheakNumber = 100;

        // Start is called before the first frame update
        void Start()
    {
                



                if (CheakNumber > 100)
                {
                        Debug.Log("CheakNumber > 0");
                }

                if (CheakNumber == 100)
                {
                        Debug.Log("CheakNumber == 0");
                }

                if (CheakNumber < 100)
                {
                        Debug.Log("CheakNumber < 0");
                }
        }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
                {
                        if (CheakNumber > 100)
                        {
                                Debug.Log("CheakNumber > 0");
                        }

                        if (CheakNumber == 100)
                        {
                                Debug.Log("CheakNumber == 0");
                        }

                        if (CheakNumber < 100)
                        {
                                Debug.Log("CheakNumber < 0");
                        }
                }



                if (Input.GetKey(KeyCode.Q))
                {
                        CheakNumber = 90;
                }





                if (Input.GetKey(KeyCode.W))
                {
                       CheakNumber = 100;
                }


                if (Input.GetKey(KeyCode.E))
                {
                        CheakNumber = 110;
                }

        }
}
