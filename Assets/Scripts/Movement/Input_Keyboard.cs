using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Keyboard : MonoBehaviour
{

        public float Speed; // 플레이어 속도
        public float WalkSpeed = 5.0f; // 걷기 속도 변수
        public float RunSpeed = 10.0f; // 달리기 속도 변수

    void Start()
    {
                Speed = WalkSpeed;
    }


        void Update()
        {
                if (Input.GetKey(KeyCode.W) == true) // 키보드 입력값 'W'를 받았을 경우
                {
                        transform.Translate(Vector3.forward * Speed * Time.deltaTime); // " 'forward' 방향으로 이동 "
                }

                else if (Input.GetKey(KeyCode.S) == true) // 키보드 입력값 'S'를 받았을 경우
                {
                        transform.Translate(Vector3.back * Speed * Time.deltaTime); // " 'back' 방향으로 이동 "
                }

                if (Input.GetKey(KeyCode.A) == true) // 키보드 입력값 'A'를 받았을 경우
                {
                        transform.Translate(Vector3.left * Speed * Time.deltaTime); // " 'left' 방향으로 이동 "
                }

                else if (Input.GetKey(KeyCode.D) == true) // 키보드 입력값 'D'를 받았을 경우
                {
                        transform.Translate(Vector3.right * Speed * Time.deltaTime); // " 'right' 방향으로 이동 "
                }



                if(Input.GetKey(KeyCode.LeftShift) == true)
                {
                        Speed = RunSpeed;
                        
                }
                else
                {
                        Speed = WalkSpeed;
                }
        }
}
