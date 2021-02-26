using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
        private int hitCount;
        public GameObject expEffect;

        public AudioClip expSfx;
        
        [SerializeField]
        private MeshRenderer renderer;

        public Texture[] textures;



        public void Start()
        {

                renderer = GetComponentInChildren<MeshRenderer>();
                int idx = Random.Range(0, textures.Length);  // (0,3) ====> 0, 1, 2
                renderer.material.mainTexture = textures[idx];
        }

        public void OnCollisionEnter(Collision collision)
        {
                if(collision.collider.CompareTag("BULLET"))
                {
                        
                        if (++hitCount == 3)
                        {
                                ExpBarrel();
                        }
                }
        }


        public void ExpBarrel()
        {
                if (GetComponent<Rigidbody>() == null)
                {

                        
                        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
                        
                        rb.AddForce(Vector3.up * 2500.0f);

                        GameObject effect = Instantiate(expEffect, transform.position, Quaternion.identity);
                        Destroy(effect, 3.5f);
                        Destroy(this.gameObject, 3.5f);

                        this.gameObject.AddComponent<AudioSource>().PlayOneShot(expSfx, 0.8f);   //PlayOneShow(음원, 소리크기);
                }
        }
}
