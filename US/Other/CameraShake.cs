using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

        // 카메라 흔들기

        public float ShakeAmount = 10f;

        //public Canvas canvas;

        float ShakeTime = 0;

        Vector3 initialPosition;

        float time = 2.0f;

        public void VibrateForTime(float time)

        {

                ShakeTime = time;

        }



        private void Start()

        {

                initialPosition = new Vector3(0f, 0f, -5f);

        }



        private void Update()

        {

                if (ShakeTime > 0)

                {

                        transform.position = Random.insideUnitSphere * ShakeAmount + initialPosition;

                        ShakeTime -= Time.deltaTime;

                }

                else

                {

                        ShakeTime = 0.0f;

                        transform.position = initialPosition;

                        //canvas.renderMode = RenderMode.ScreenSpaceCamera;

                }

        }
}
