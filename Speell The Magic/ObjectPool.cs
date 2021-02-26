using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool Instance;
    [SerializeField]

    private GameObject poolingObjectPrefab;



    Queue<Magic_Object> poolingObjectQueue = new Queue<Magic_Object>();



    private void Awake()

    {
        Instance = this;
        Initialize(10);

    }
    private void Initialize(int initCount)

    {

        for (int i = 0; i < initCount; i++)

        {

            poolingObjectQueue.Enqueue(CreateNewObject());

        }

    }



    private Magic_Object CreateNewObject()

    {

        var newObj = Instantiate(poolingObjectPrefab).GetComponent<Magic_Object>();

        newObj.gameObject.SetActive(false);

        newObj.transform.SetParent(transform);

        return newObj;

    }



    public static Magic_Object GetObject()

    {

        if (Instance.poolingObjectQueue.Count > 0)

        {

            var obj = Instance.poolingObjectQueue.Dequeue();

            obj.transform.SetParent(null);

            obj.gameObject.SetActive(true);

            return obj;

        }

        else

        {

            var newObj = Instance.CreateNewObject();

            newObj.gameObject.SetActive(true);

            newObj.transform.SetParent(null);

            return newObj;

        }

    }



    public static void ReturnObject(Magic_Object obj)

    {

        obj.gameObject.SetActive(false);

        obj.transform.SetParent(Instance.transform);

        Instance.poolingObjectQueue.Enqueue(obj);

    }

}


