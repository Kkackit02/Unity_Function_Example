using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 4.0f;
    public float jumpPower = 10.0f;
    public float Player_HP = 100f;
    public float Player_DashPower = 15f;
    
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public float checkGroundRadius = 0.5f;

    public Animator Player_Ani;
    public SpriteRenderer Player_Sprite;
    public Rigidbody2D Player_Rig;
    public Transform isGroundedChecker;

    public LayerMask groundLayer;

    bool isGrounded = false;

    public Transform Player_Foot_transform;
    public GameObject Dash_Effect;

    public string DashKey = "";

    public bool Dash_coolTime = false;


    void Start()
    {

        Player_Ani = GetComponent<Animator>();
        Player_Sprite = GetComponent<SpriteRenderer>();
        Player_Rig = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    
    void Update()
    {
        Jump();
        BetterJump(); //롱점프
        CheckIfGrounded();
        Check_Dash();
        Move();
    }


    void Move()
    {


        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Time.deltaTime * Speed);
            Player_Sprite.flipX = true;
            Player_Ani.SetBool("run", true);
           
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * Speed);
            Player_Sprite.flipX = false;
            Player_Ani.SetBool("run", true);
   
        }

        else
        {
            Player_Ani.SetBool("run", false);
        }

        
    }




    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Player_Ani.SetTrigger("Jump");
            Player_Rig.velocity = new Vector2(Player_Rig.velocity.x, jumpPower);
        }
    }


    void BetterJump()
    {
        if (Player_Rig.velocity.y < 0)
        {
            Player_Rig.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (Player_Rig.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            Player_Rig.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }


    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (collider != null)
        {
            isGrounded = true;
            Player_Ani.SetBool("isGround", true);
        }
        else
        {
            isGrounded = false;
            Player_Ani.SetBool("isGround", false);
        }
    }


    public void Check_Dash()
    {
        if (Input.GetKeyDown(KeyCode.A) == true)
        {
            StartCoroutine("Dash");
        }

        else if (Input.GetKeyDown(KeyCode.D) == true)
        {           
            StartCoroutine("Dash");
        }

        if (Input.GetKeyUp(KeyCode.A) == true)
        {
            DashKey = "A";
        }
        else if (Input.GetKeyUp(KeyCode.D) == true)
        {
            DashKey = "D";
        }
    }

    public IEnumerator Dash()
    {
        if(DashKey == "A")
        {
            if(Dash_coolTime == false)
            {
                if (Input.GetKeyDown(KeyCode.A) && isGrounded == true)
                {
                    //Player_Rig.velocity = new Vector2(Player_Rig.velocity.x, Player_DashPower);
                    Player_Rig.AddForce(new Vector3(-1, 0, 0) * Player_DashPower, ForceMode2D.Impulse);
                    Dash_coolTime = true;
                    StartCoroutine("CoolTime_Dash");
                    Instantiate(Dash_Effect, Player_Foot_transform);
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    DashKey = "";
                    StopCoroutine("Dash");
                }
            }
            
        }

        else if(DashKey == "D")
        {
            if (Dash_coolTime == false)
            {
                if (Input.GetKeyDown(KeyCode.D) && isGrounded == true)
                {
                    //Player_Rig.velocity = new Vector2(Player_Rig.velocity.x, Player_DashPower);
                    Player_Rig.AddForce(new Vector3(1, 0, 0) * Player_DashPower, ForceMode2D.Impulse);
                    Dash_coolTime = true;
                    StartCoroutine("CoolTime_Dash");
                    Instantiate(Dash_Effect, Player_Foot_transform);
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    DashKey = "";
                    StopCoroutine("Dash");
                }
            }

        }

        yield return new WaitForSecondsRealtime(1f);
        DashKey = "";

    }


    public IEnumerator CoolTime_Dash()
    {
        yield return new WaitForSeconds(2f);
        Dash_coolTime = false;
    }

    public void Melee_Attack_Check()
    {
        if(Input.GetMouseButtonDown(3) || Input.GetKeyDown(KeyCode.F))
        {
            Player_Ani.SetTrigger("Melee");

            Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
            if (collider != null)
            {
                isGrounded = true;
                Player_Ani.SetBool("isGround", true);
            }
            else
            {
                isGrounded = false;
                Player_Ani.SetBool("isGround", false);
            }

        }
        
    }

}
