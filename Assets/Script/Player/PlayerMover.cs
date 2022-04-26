using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum INFO
{
    HP,
    ATT,
    DF,
    SPEED,
    CRIT,

    SIZE
}


public class PlayerMover : MonoBehaviour
{

    Rigidbody2D rigid;
    Collider2D collider;
    Animator anim;

    INFO info;

    public float moveSpeed = 5f;
    public float jumpForce = 3f;
    public float dashForce = 8f;
    float horizon;

    float hSpeed;
    float vSpeed;
    bool _isJump;
    bool isGround
    {
        set
        {
            _isJump = value;
            anim.SetBool("IsJump", value);
        }
        get
        {
            return anim.GetBool("IsJump");
        }
    }
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Vector2 startvec = new Vector2(collider.transform.position.x, collider.transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(startvec, Vector2.down, 1.5f, LayerMask.GetMask("Ground"));
        if (null != hit.collider)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
        Move();
    }
    private void Update()
    {
        Jump();
        Dash();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
    private void Move()
    {
        hSpeed = Input.GetAxis("Horizontal") * moveSpeed;
        anim.SetFloat("hSpeed", Mathf.Abs(hSpeed));
        transform.Translate(Vector2.right * hSpeed * Time.fixedDeltaTime);
        if (hSpeed < 0)
            transform.localScale = new Vector2(-1, 1);
        else if (hSpeed > 0)
            transform.localScale = new Vector2(1, 1);
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGround == true)
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        vSpeed = rigid.velocity.y;
        anim.SetFloat("vSpeed", vSpeed);
    }
    private void Dash()
    {
        hSpeed = Input.GetAxisRaw("Horizontal") * moveSpeed;
        if (Input.GetButtonDown("Dash") /*&& 대쉬 조건문 추가*/)
        {
            anim.SetTrigger("IsDash");
            if(hSpeed < 0)
            {
                rigid.AddForce(Vector2.left * dashForce,ForceMode2D.Impulse);
            }
            else if(hSpeed > 0)
            {
                rigid.AddForce(Vector2.right * dashForce,ForceMode2D.Impulse);
            }
        }
    }
}
