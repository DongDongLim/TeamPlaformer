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
    Collider2D playerCollider;
    Animator anim;

    INFO info;

    public float moveSpeed = 5f;
    public float jumpForce = 3f;
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
        playerCollider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Vector2 startvec = new Vector2(playerCollider.transform.position.x, playerCollider.transform.position.y);
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
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            // anim.SetBool("IsJump", isJump);
        }
        vSpeed = rigid.velocity.y;
        anim.SetFloat("vSpeed", vSpeed);
    }
}
