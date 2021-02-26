using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
        public GameObject Bullet;
        public Transform target;
        public GameObject target_O;

        public float min = 0.5f;
        public float max = 3.0f;


        private float spawnRate; // 생성주기
        private float AfterTime; //최근 생성 시점에서 지난 시간
    void Start()
    {
                AfterTime = 0f;

                spawnRate = Random.Range(min, max);
                // 스폰 주기를 최대, 최소 값 사이에서 랜덤 지정

                
    }

    // Update is called once per frame
    void Update()
    {

                AfterTime += Time.deltaTime;


                if (AfterTime >= spawnRate)
                {
                        AfterTime = 0;
                        GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
                        //총알을 생성기  방향, 위치로 생성
                        bullet.transform.LookAt(target);
                        //총알이 타겟을 바라보게 회전

                        spawnRate = Random.Range(min, max);
                }

    }
}
