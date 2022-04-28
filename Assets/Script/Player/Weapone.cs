﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapone : MonoBehaviour
{
    //public SkillData skill;
    BoxCollider2D boxCollider;
    Animator anime;
  

    public GameObject preFad;
    public ParticleSystem hitParticle;

    float attackDelay = 0;
    bool isAttacked;
    public float hitDistance = 3f;

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
        if (Input.GetButtonDown("nomalAtt") && !isAttacked && attackDelay <= 0)
        {
            isAttacked = true;
            boxCollider.enabled = true;
            anime.SetBool("IsAttacked", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Monster")/*몬스터*/)
        {
            Debug.Log("attcked!!!");
            GameObject obj = Instantiate(preFad,transform.position,Quaternion.identity);
            obj.GetComponent<ParticleSystem>().Play();
            IDamaged target = GetComponent<IDamaged>();


            other.rigidbody.AddForce(new Vector2(transform.position.x * hitDistance * Time.deltaTime, transform.position.y),ForceMode2D.Impulse);
            //target.Damaged();

            //TODO : monster의 hp가 달게
        }

    }
}
