using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IDamaged
{
    [SerializeField]
    State[] state;

    [SerializeField]
    ItemData[] dropItem;

    
    public SkillData atk;

    [SerializeField]
    float Hp;

    [SerializeField]
    public int Speed;

    public float AtkRange;

    public float MoveRange;

    [SerializeField]
    State curState;

    public Vector2 StdVector;


    [SerializeField]
    public GameObject target = null;

    public Animator anim;

    RaycastHit2D hit;

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
        curState?.Enter();
    }

    public void Damaged(SkillData data)
    {
        switch(data.Use())
        {
            case SkillData.SkillType.NOMMAL:
                Hp -= data.m_skillInfo.atk;
                if (Hp <= 0)
                    Die();
                break;
            case SkillData.SkillType.STUN:
                break;
        }
    }

    private void Update()
    {
        PattenCheck();
        curState?.Stay();
        
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
                }
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
