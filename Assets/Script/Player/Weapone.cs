﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapone : MonoBehaviour
{
    //public SkillData skill;
    BoxCollider2D boxCollider;
    Animator anime;

    public GameObject hitUI;
    public GameObject potion;


    float attackDelay = 0;
    bool isAttacked;
    public float hitDistance = 3f;

    bool skillCoolTime;
    float skilltime;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anime = GetComponent<Animator>();
        skillCoolTime = false;
        skilltime = 0;
    }
    private void FixedUpdate()
    {
        if (isAttacked)
        {
            attackDelay += Time.deltaTime;
            if (attackDelay >= 0.2f)
            {
                attackDelay = 0;
                isAttacked = false;

                boxCollider.enabled = false;
            }
        }
    }
    private void Update()
    {
        Attacked();
        CoolTime();

    }
    private void Attacked()
    {
        if (Input.GetButtonDown("nomalAtt") && !isAttacked && attackDelay <= 0)
        {
            isAttacked = true;
            boxCollider.enabled = true;
            anime.SetTrigger("IsAttacked");
        }
        if (Input.GetButtonDown("Skill") && skillCoolTime == false)
        {
            anime.SetTrigger("IsAttacked");
            skillCoolTime = true;
            GameObject obj = Instantiate(potion, transform.position, Quaternion.identity);
        }
    }

    private void CoolTime()
    {
        if (skillCoolTime)
        {
            skilltime += Time.deltaTime;
            if (skilltime >= 0.5f)
            {
                skillCoolTime = false;
                skilltime = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Monster")/*몬스터*/)
        {
            Debug.Log("attcked!!!");
            GameObject obj = Instantiate(hitUI, transform.position, Quaternion.identity);

            obj.GetComponent<ParticleSystem>().Play();

            IDamaged target = GetComponent<IDamaged>();
            //target.Damaged();

            //TODO : monster의 hp가 달게
        }
    }

}