using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public AudioClip fireSfx;
    private AudioSource source;
    private MeshRenderer muzzleFlash;
        private RaycastHit hit;


        void Start()
        {
                source = GetComponent<AudioSource>();
                muzzleFlash = transform.Find("FirePos/MuzzleFlash").GetComponent<MeshRenderer>();
                muzzleFlash.enabled = false;    
        }



        void Update()
    {

                Debug.DrawRay(firePos.position , firePos.forward * 10.0f, Color.green);



        //마우스 왼쪽 버튼을 한번 클릭했을 때
        if (Input.GetMouseButtonDown(0))
        {

                        
                        if (Physics.Raycast(firePos.position,  //위치
                                firePos.forward, //방향
                                out hit, //무슨 레이를 쏠지
                                10.0f,  //몇 미터까지
                                1 << 8))  //검출레이어 -> 비트단위로 연산(플래그값 사용에 사용 -> 비트연산은 산술연살자와 마찬가지로 논리연산(비트연산)0가능)
                                // 1<< 8 | 1<<9 , ~(1<<10) 등
                        {
                                //Debug.Log(hit.collider.name);

                                hit.collider.GetComponent<MonsterCtrl>().Damage(10.0f);


                        }
                        
                        fire();
        }
    }


        void fire()
        {

                //동적 총알(Bullet)을 생성 (생성할 객체, 위치, 회전)
                Instantiate(bullet, firePos.position, firePos.rotation);
                //총소리 발생(소리를 중첩해서 발생)
                source.PlayOneShot(fireSfx);
                StartCoroutine(ShowMuzzleFalsh());
                
        }


        IEnumerator ShowMuzzleFalsh()
        {
                //텍스처를 변경 Offset
                float offsetX = (float)Random.Range(0, 2) * 0.5f;
                float offsetY = (float)Random.Range(0, 2) * 0.5f;

                muzzleFlash.material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));



                float angle = Random.Range(0.0f, 360.0f);
                muzzleFlash.transform.localRotation = Quaternion.Euler(0, 0, angle);
                //muzzleFalsh 스케일
                float scale = Random.Range(0.7f, 1.8f);
                muzzleFlash.transform.localScale = Vector3.one * scale;



                //총구화염을 활성화
                muzzleFlash.enabled = true;

                yield return new WaitForSeconds(0.2f);
                //충구화염을 비활성화
                muzzleFlash.enabled = false;


        }
}
