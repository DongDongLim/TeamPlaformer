using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public Rigidbody2D rigid;
    public GameObject preFab;
    CircleCollider2D coll;


    ParticleSystem particle;

    public float power = 5f;
    float hSpeed;

    Vector2 playerPos;

    private void Start()
    {
        coll = GetComponent<CircleCollider2D>();
        Use();
    }
    private void Update()
    {
        
    }

    private void Use()
    {
        hSpeed = Input.GetAxisRaw("Horizontal") * 5f;
        Player Pos = FindObjectOfType<Player>();
        playerPos = Pos.gameObject.transform.position;
        rigid.AddForce(new Vector2(hSpeed * power, 350f) * Time.deltaTime, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground") ^ other.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            Magic();
            Destroy(gameObject);
        }
    }
    
   
    private void Magic()
    {
        GameObject objp = Instantiate(preFab, transform.position, Quaternion.identity);
        objp.GetComponent<ParticleSystem>().Play();
        RaycastHit2D hit = Physics2D.Raycast(objp.transform.position, new Vector2(hSpeed, 0), 5f, LayerMask.GetMask("Monster"));
        Debug.DrawRay(objp.transform.position, Vector2.up * 10f, new Color(0, 0, 1));
        if (null != hit.collider)
        {
            Debug.Log("작동");
            IDamaged target = hit.collider.GetComponent<IDamaged>();
            //target.damaged;

            Destroy(objp, 0.5f);
        }
        else
        {
            Debug.Log("비작동");
            Destroy(objp, 0.5f);
            return;
        }
        
        
       

    }
    
}
