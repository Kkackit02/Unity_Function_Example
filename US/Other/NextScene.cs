using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
        public int stageLevel = 0;
        public int curScene;
        public int nextScene;
        Scene scene;
        void Start()
    {
                Scene scene = SceneManager.GetActiveScene(); // 현재 씬 정보
                stageLevel = scene.buildIndex;


                nextScene = stageLevel + 1;
        }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void OnTriggerEnter2D(Collider2D collision)
        {
                if(collision.tag == "Player")
                {
                        SceneManager.LoadScene(nextScene);
                }
        }


        public void NextS()
        {
                SceneManager.LoadScene(nextScene);
        }

        public void End_Revolution()
        {
                SceneManager.LoadScene("3-1 revolution");
        }

        public void End_Excape()
        {
                SceneManager.LoadScene("3-1 Excape");
        }
}
