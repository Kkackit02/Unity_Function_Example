using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextStage : MonoBehaviour
{
        public int stageLevel = 0;
        public int curScene;
        public int nextScene;
        Scene scene;

        public void Start()
        {
                Scene scene = SceneManager.GetActiveScene(); // 현재 씬 정보
                stageLevel = scene.buildIndex;


                nextScene = stageLevel + 1;
                curScene = stageLevel;

        }

        // Update is called once per frame
        void Update()
    {
        if(Input.GetKey(KeyCode.P))
                {
                        OnClickNextBtn();
                }
    }



        void OnTriggerEnter2D(Collider2D collision)
        {
                if (collision.gameObject.tag == "Player")
                {
                        OnClickNextBtn();
                }
        }

        public void OnClickNextBtn()
        {


                SceneManager.LoadScene(nextScene);
        }
}
