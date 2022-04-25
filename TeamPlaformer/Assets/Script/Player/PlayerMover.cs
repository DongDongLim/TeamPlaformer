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
    float horizon;

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
        Move();
        Jump();
    }
    private void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
    private void Move()
    {
        horizon = Input.GetAxis("Horizontal") * moveSpeed;
        transform.Translate(Vector2.right * horizon * Time.deltaTime);
        anim.SetBool("IsMove", true);
        if (horizon > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (horizon < 0)
        {

            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            anim.SetBool("IsMove", false);
        }
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGround == true)
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            // anim.SetBool("IsJump", isJump);
        }
        vSpeed = rigid.velocity.y;
        anim.SetFloat("vSpeed", vSpeed);
    }
}
