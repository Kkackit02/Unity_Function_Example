using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public List<GameObject> corona = new List<GameObject>();
    void Start()
    {
        StartCoroutine(Start_Trigger());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator Start_Trigger()
    {
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(Random_Walk_Run());
    }
    IEnumerator Random_Walk_Run()
    {
        while (true)
        {
            StartCoroutine(Do());
            yield return new WaitForSeconds(0.0000001f);
        }
    }
    
    IEnumerator Do()
    {
        for (int i = 0; i < 11; i++)
        {
            corona[Random.Range(0, 500)].gameObject.GetComponent<Random_Walk>().Moving();
            yield return new WaitForSeconds(0.0000000001f);
        }
        
    }

}
