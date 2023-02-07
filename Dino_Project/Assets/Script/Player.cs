using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpPower = 5f; // 점프 높이
    public bool isGrounded = false;
    public int jumpCount = 2; // 점프횟수 2단 점프
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator anim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        jumpCount = 0;
        isGrounded = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag == "Ground") // 충돌처리
        {
            isGrounded = true;
            jumpCount = 2;
            anim.SetBool("isJump", false);
        }
    }

    void Update()
    {
        if(isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow) && jumpCount > 0)
        {
            rb.velocity = Vector2.up * jumpPower;
            --jumpCount; // 점프할때 마다 점프횟수 감소 // 무한 점프 방지
            anim.SetBool("isJump", true);
        }

        // 수그리기
        if(Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("isDown", true);
        }
        else
        {
            anim.SetBool("isDown", false);
        }
    }
}
