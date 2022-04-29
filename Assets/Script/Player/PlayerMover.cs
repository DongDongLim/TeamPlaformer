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
    public float dashForce = 8f;
    float horizon;

    float hSpeed;
    float vSpeed;

    float dashDelay = 0;
    bool isDash;

    bool _isJump;

    GameObject isNpc = null;

    bool isGround
    {
        set
        {
            _isJump = value;
            if (!isDash)
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
        //대시 딜레이
        if (isDash)
        {
            dashDelay += Time.deltaTime;
            if (dashDelay >= 1.2f)
            {
                dashDelay = 0;
                isDash = false;
            }
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
        if (other.gameObject.layer == LayerMask.NameToLayer("NPC"))
        {
            isNpc = other.gameObject;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("NPC"))
        {
            isNpc = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("NPC"))
        {
            isNpc = null;
        }
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
        if (null != isNpc)
        {
            if (Input.GetButtonDown("Jump") && isGround == true)
            {
                IInteraction inter = isNpc.GetComponent<IInteraction>();
                inter?.ReAction();
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && isGround == true)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
                rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            vSpeed = rigid.velocity.y;
            anim.SetFloat("vSpeed", vSpeed);
        }
    }
    private void Dash()
    {
        hSpeed = Input.GetAxis("Horizontal") * moveSpeed;
        if (Input.GetButtonDown("Dash") && dashDelay <= 0 && anim.GetFloat("hSpeed") >= 1 && isGround)
        {
            isDash = true;
            anim.SetTrigger("IsDash");
            if (hSpeed < 0)
            {
                rigid.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
            }
            else if (hSpeed > 0)
            {
                rigid.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
            }
        }
    }
}
