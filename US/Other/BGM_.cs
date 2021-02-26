using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





public class BGM_ : MonoBehaviour
{

        public AudioSource audioSource;

        public AudioClip Suspect;
        public AudioClip Excape;
        public AudioClip Autumn;
        public AudioClip WithOut;
        public AudioClip Eye;
        public AudioClip Guilty;
        public AudioClip River;
        public AudioClip Bunker;
        public AudioClip LastDay;
        public AudioClip Main;

        public bool cheak = false;
        private void Awake()
        {
                audioSource = GetComponent<AudioSource>();
                if (SceneManager.GetActiveScene().name == "MainMenu")
                {
                        audioSource.clip = Main; //오디오에 bgm이라는 파일 연결
                }

        }
        void Start()
        {
                Debug.Log("Start");
                
                




                audioSource.volume = 0.5f; //0.0f ~ 1.0f사이의 숫자로 볼륨을 조절
                audioSource.loop = true; //반복 여부
                audioSource.mute = false; //오디오 음소거

                audioSource.Play(); //오디오 재생



                DontDestroyOnLoad(transform.gameObject); 

        }

        // Update is called once per frame
        void OnLevelWasLoaded()
    {



                if (SceneManager.GetActiveScene().name == "MainMenu")
                {
                        if(cheak == false)
                        {
                                audioSource.clip = Main; //오디오에 bgm이라는 파일 연결
                                audioSource.Play();
                        }

                        if (cheak == true)
                        {
                                Destroy(this.gameObject);
                        }
                        
                }
                else if (SceneManager.GetActiveScene().name == "1-1 Prologue")
                {
                        audioSource.clip = Autumn; //오디오에 bgm이라는 파일 연결
                        audioSource.Play();
                }
                else if (SceneManager.GetActiveScene().name == "1-5 Excape Home" )
                       
                {
                        audioSource.clip = Excape; //오디오에 bgm이라는 파일 연결
                        audioSource.Play();
                }
                else if (SceneManager.GetActiveScene().name == "1-9 Train_City")
                {
                        audioSource.clip = Suspect; //오디오에 bgm이라는 파일 연결
                        audioSource.Play();
                }
                else if (SceneManager.GetActiveScene().name == "2-1 dia")
                {
                        audioSource.clip = Eye; //오디오에 bgm이라는 파일 연결
                        audioSource.Play();
                }
                else if (SceneManager.GetActiveScene().name == "2-3 Bunker")
                {
                        audioSource.clip = Bunker; //오디오에 bgm이라는 파일 연결
                        audioSource.Play();
                }
                else if (SceneManager.GetActiveScene().name == "2-6 AttackedBunker")
                {
                        audioSource.clip = Suspect; //오디오에 bgm이라는 파일 연결
                        audioSource.Play();
                }
                else if (SceneManager.GetActiveScene().name == "3-0 Ending")
                {
                        audioSource.clip = River; //오디오에 bgm이라는 파일 연결
                        audioSource.Play();
                }
                else if (SceneManager.GetActiveScene().name == "3-1 Excape")
                {
                        audioSource.clip = Guilty; //오디오에 bgm이라는 파일 연결
                        audioSource.Play();
                }
                else if (SceneManager.GetActiveScene().name == "3-1 revolution")
                {
                        audioSource.clip = WithOut; //오디오에 bgm이라는 파일 연결
                        audioSource.Play();
                }

                 //오디오 재생
        }
}
