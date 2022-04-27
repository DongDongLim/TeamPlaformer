using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IDamaged
{
    [SerializeField]
    State[] state;

    [SerializeField]
    ItemData[] dropItem;

    [SerializeField]
    SkillData atk;

    [SerializeField]
    float Hp;

    [SerializeField]
    public int Speed;

    public int AtkRange;

    [SerializeField]
    State curState;

    [SerializeField]
    public GameObject target = null;

    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        foreach(State st in state)
        {
            st.SetOwner(this);
        }
    }


    public void Trade(State newState)
    {
        curState?.Exit();
        curState = newState;
    }

    public void Damaged(SkillData data)
    {
        
        Hp -= data.atk;
        if (Hp <= 0)
            Die();
    }

    private void Update()
    {
        PattenCheck();
        curState.Stay();
    }

    void PattenCheck()
    {
        foreach(State st in state)
        {
            if (st.Condition())
            {
                if (st != curState)
                {
                    Trade(st);
                    return;
                }
            }
            else
            {
                if (st == curState)
                    return;
            }
        }
    }

    void Die()
    {
        GameMng.instance.RemoveObj(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            target = collision.gameObject;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            target = null;
        }
    }
}
