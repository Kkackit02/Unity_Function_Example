using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music_Slider : MonoBehaviour
{
        public AudioSource BackGround_Audio;
        public AudioSource Effect_Audio;

        public AudioClip bgm1; //1번 배경음악
        public AudioClip bgm2; //1번 배경음악


        public AudioClip hit;
        public AudioClip Run;
        public AudioClip Walk;
        public AudioClip UISound;
        public AudioClip Opne_Door;





        public Slider BackGroundBar;
        public Slider EffactBar;
        public Slider MasterBar;



        void Start()
        {

                BackGround_Audio = GetComponent<AudioSource>();
                //Audio.clip = Audio; 
                BackGround_Audio.clip = bgm1;

                BackGround_Audio.playOnAwake = true; //신 시작시 재생 여부. 필요시 True를 False로 바꿔 주세요, 그리고 음악은 Audio.Play() 함수로 재생합니다.
                BackGround_Audio.loop = true; //반복 여부. 필요시 True를 False로 바꿔 주세요
                BackGround_Audio.mute = false; //오디오 음소거. 필요시 True를 False로 바꿔 주세요
        }
        void Update()
        {
                
                BackGround_Audio.volume = BackGroundBar.value * MasterBar.value;
                Effect_Audio.volume = BackGroundBar.value * MasterBar.value;


        }
        public void Click_UI()
        {
                BackGround_Audio.PlayOneShot(UISound);
        }

}

