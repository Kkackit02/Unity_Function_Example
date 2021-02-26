using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Effect : MonoBehaviour
{
    // Start is called before the first frame update

    public void OnEnable()
    {
        Invoke("Destroy_This", 1f);
    }

    // Update is called once per frame
    public void Destroy_This()
    {
        Destroy(this.gameObject);
    }
}
