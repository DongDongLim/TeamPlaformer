using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapone : MonoBehaviour
{
    BoxCollider2D boxCollider;
    Animator anime;

    float attackDelay = 0;
    bool isAttacked;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anime = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (isAttacked)
        {
            attackDelay += Time.deltaTime;
            if(attackDelay >= 0.2f)
            {
                attackDelay = 0;
                isAttacked = false;
                anime.SetBool("IsAttacked", false);
                boxCollider.enabled = false;
            }
        }
    }
    private void Update()
    {
        Attacked();

    }
    private void Attacked()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacked && attackDelay <= 0)
        {
            isAttacked = true;
            boxCollider.enabled = true;
            anime.SetBool("IsAttacked", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Monster")
        {
            //monster의 hp가 달게
        }
    }
}
