using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
        public int stageLevel = 0;
        public  int curScene;
        public int nextScene;
        Scene scene;

        public void Start()
        {
                Scene scene = SceneManager.GetActiveScene(); // 현재 씬 정보
                stageLevel = scene.buildIndex ;


                nextScene = stageLevel + 1;
                curScene = stageLevel ;

        }

        public void OnClickNextBtn()
        {

                
                SceneManager.LoadScene(nextScene);
        }


        public void OnClickRestartBtn()
        {
                
                SceneManager.LoadScene(curScene);
        }


        public void OnClickMainMenuBtn()
        {
                SceneManager.LoadScene(0);
        }


        public void OnClickOptionBtn()
        {

        }

     public void OnClickExitBtn()
        {
                Application.Quit();
        }
}
