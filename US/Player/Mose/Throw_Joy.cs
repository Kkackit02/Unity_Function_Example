using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Throw_Joy : MonoBehaviour
{


// 공개
    public Transform Thrower;
public Transform Stick;         // 조이스틱.
public float power = 7.5f;         // 조이스틱.

// 비공개
private Vector3 StickFirstPos;  // 조이스틱의 처음 위치.
private Vector3 JoyVec;         // 조이스틱의 벡터(방향)
private float Radius;           // 조이스틱 배경의 반 지름.
private Quaternion Right = Quaternion.identity;

public GameObject Shoot; //발사할 레이저를 저장합니다.
public bool canShoot = true; //레이저를 쏠 수 있는 상태인지 검사합니다.
const float shootDelay = 0.5f; //레이저를 쏘는 주기를 정해줍니다.
float shootTimer = 0; //시간을 잴 타이머를 만들어줍니다.

        public int haveBottle;
        public GameObject inventory;
        public Inventory inventory_Script;

        public AudioSource AS;
        public AudioClip a;
        public Animator Player_ani;

void Start()
{
                Player_ani = GameObject.Find("Player_M").GetComponent<Animator>();
        Radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        StickFirstPos = Stick.transform.position;

        // 캔버스 크기에대한 반지름 조절.
        float Can = transform.parent.GetComponent<RectTransform>().localScale.x;
        Radius *= Can;
}

// 드래그
public void Drag(BaseEventData _Data)
{
        Global.IsArrowShow = true;
        Global.ArrowAngle = Mathf.Atan2(JoyVec.x, JoyVec.y) * Mathf.Rad2Deg;
        PointerEventData Data = _Data as PointerEventData;
        Vector3 Pos = Data.position;

        // 조이스틱을 이동시킬 방향을 구함.(오른쪽,왼쪽,위,아래)
        JoyVec = (Pos - StickFirstPos).normalized;

        // 조이스틱의 처음 위치와 현재 내가 터치하고있는 위치의 거리를 구한다.
        float Dis = Vector3.Distance(Pos, StickFirstPos);

        // 거리가 반지름보다 작으면 조이스틱을 현재 터치하고 있는곳으로 이동. 
        if (Dis < Radius)
                Stick.position = StickFirstPos + JoyVec * Dis;
        // 거리가 반지름보다 커지면 조이스틱을 반지름의 크기만큼만 이동.
        else
                Stick.position = StickFirstPos + JoyVec * Radius;

}
private void Update()
{
        shootTimer += Time.deltaTime; //쿨타임을 카운트 합니다.
}
// 드래그 끝.
public void DragEnd()
{

        Global.IsArrowShow = false;
        Stick.position = StickFirstPos; // 스틱을 원래의 위치로.
        Right.eulerAngles = new Vector3(0, 0, Mathf.Atan2(JoyVec.x, JoyVec.y) * Mathf.Rad2Deg * -1);
        Global.PowerX = JoyVec.x;
        Global.PowerY = JoyVec.y;
        //Global.BottlePower = Mathf.Abs(JoyVec.x) * Mathf.Abs(JoyVec.y) * power;
        Global.BottlePower = 8f;
        print(Global.BottlePower);
                inventory_Script.Minus_Bottle();
                Instantiate(Shoot, Thrower.transform.position, Right);
                AS.PlayOneShot(a);
                Player_ani.SetTrigger("isThrow");
        
        JoyVec = Vector3.zero;          // 방향을 0으로
}




}