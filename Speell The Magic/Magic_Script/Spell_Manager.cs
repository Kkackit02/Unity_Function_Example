using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.UI;


public class Spell_Manager : MonoBehaviour
{
    
    public float High_Speed_Compute_Mana_Cost = -1f;
    public float FireBall_Mana_Cost = -5f;


    public bool High_Speed_Compute_Mana_Boolean = false;

    public string Input_Key;
    
    public Text Input_Key_Text;
    public Text Skill_Key_Text;
    

    public List<string> Combination = new List<string>();

    public List<string> Skill_Key_List = new List<string>();

    public string Skill_Type = ""; //Normal, Fire, Water, Wind, Earth, Dark, Light, Electricity 
    public string Skill_Form = ""; //Projectile, Self
    public string Skill_FirePoint = ""; //Onself, Gate
    public string Skill_Key = "";

    private Camera mainCam;


    Vector2 MousePosition;
    Vector2 PlayerPosition;
    public Transform MuzzlePosition;


    public GameObject Player;
    void Start()

    { 
        mainCam = Camera.main;
        Skill_Type_Reset();
        StartCoroutine("High_Speed_Compute_Use");
        
    }

    

    // Update is called once per frame
    void Update()
    {
        GetKey();
        High_Speed_Compute();
        ShowKey();

        
    }


    IEnumerator High_Speed_Compute_Use()
    {
        while (true)
        {
            if (High_Speed_Compute_Mana_Boolean == true)
            {
                GameManager.Instance.UpdateMP(High_Speed_Compute_Mana_Cost);
                yield return new WaitForSecondsRealtime(1.0f);
                Debug.Log("Load Coroutine");
            }

            else
            {
                yield return new WaitForSecondsRealtime(1.0f);
            }

        }
        
    }
    

    void High_Speed_Compute()
    {
        if (Input.GetMouseButton(1) == true && GameManager.Instance.Player_MP > 1)
        {
            Time.timeScale = 0.1f;

            High_Speed_Compute_Mana_Boolean = true;
            
        }
        else
        {
            High_Speed_Compute_Mana_Boolean = false;
            Time.timeScale = 1f;

        }
    }

    void GetKey()
    {



        if (Input.GetMouseButton(0) == true)
        {
            Input_Key += Input.inputString.ToUpper();
 
        }
        
        if (Input.GetMouseButtonUp(0) == true)
        {
            MakeProjectile("value");
            Debug.Log("Fire");
            //Skill_Key_List[Type/Form/Muzzle] 0/1/2
        
            Skill_Type_Reset();


        }

        else
        {
            Input_Key = "";
            Skill_Key = "";
            Skill_Type_Reset();
        }




    }

    void Skill_Type_Reset()
    {
        Skill_Type = "";
        Skill_Form = "";
        Skill_FirePoint = "";
    }
  



   


    void MakeProjectile(string value)
    {
        if(value == "")
        {
            return;
        }
        else
        {
            MousePosition = Input.mousePosition;
            MousePosition = mainCam.ScreenToWorldPoint(MousePosition);
            PlayerPosition = Player.transform.position;
            Vector2 Dir = MousePosition - PlayerPosition;


            var bullet = ObjectPool.GetObject(); // 수정

            Magic_Object magic_Object = bullet.GetComponent<Magic_Object>();
            magic_Object.transform.position = MuzzlePosition.transform.position;
            magic_Object.Launch(Dir.normalized, 500);
            GameManager.Instance.UpdateMP(FireBall_Mana_Cost);
        }
    }










    

    void ShowKey()
    {
        Input_Key_Text.text = Input_Key;
        Skill_Key_Text.text = Skill_Key;
    }
}