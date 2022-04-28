using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IDamaged
{
    Animator anim;
    Rigidbody2D rigid;

    public int HP = 5;

    

    private void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            IDamaged target = GetComponent<IDamaged>();
            //target.Damaged();
        }
    }
    public void Damaged(SkillData data)
    {

        anim.SetTrigger("damage");
        HP -= data.atk;
        if(HP <= 0)
        {

        }
    }
}
