using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{


    


    public float Player_HP = 100f;
    public float Player_MP = 100f;


    private static GameManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void InitGame()
    {

    }

    public void PauseGame()
    {

    }

    public void ContinueGame()
    {

    }

    public void RestartGame()
    {

    }

    public void StopGame()
    {

    }


    public void UpdateHP(float value)
    {
        Player_HP += value;
        Player_HP_Text.text = Player_HP.ToString();
        Player_HP_Slider.value = Player_HP;

    }


    public void UpdateMP(float value)
    {
        Player_MP += value;
        Player_MP_Text.text = Player_MP.ToString();
        Player_MP_Slider.value = Player_MP;
    }

    public void SetHP_MP(float HP, float MP)
    {
        Player_MP = MP;
        Player_HP = HP;

        Player_HP_Text.text = Player_HP.ToString();
        Player_MP_Text.text = Player_MP.ToString();
        Player_HP_Slider.value = Player_HP;
        Player_MP_Slider.value = Player_MP;


    }


    public void Start()
    {
        SetHP_MP(Player_HP, Player_MP);
    }
}
