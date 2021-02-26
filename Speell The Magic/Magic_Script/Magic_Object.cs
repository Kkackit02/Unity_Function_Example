using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Object : MonoBehaviour
{
    Rigidbody2D rigidbody_Magic;

    
    void Awake()
    {
        rigidbody_Magic = GetComponent<Rigidbody2D>();
        
    }

    public void Update()
    {
         
    }
    public void OnEnable()
    {
        StartCoroutine("Time_Destroy");
    }

    public void Launch(Vector2 Direction, float Speed)
    {
        rigidbody_Magic.AddForce(Direction * Speed);
    }

    private void OnCollisionEnter2D(Collision2D collision) //trigger과는 다르게 수학 연산 수행
    {
        if (collision.gameObject.CompareTag("Wall") == true)
        {
            ObjectPool.ReturnObject(this);
        }
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy_Health>();

        }


    }
    public IEnumerator Time_Destroy()
    {

        yield return new WaitForSeconds(10f);
        ObjectPool.ReturnObject(this);

    }


  

}

