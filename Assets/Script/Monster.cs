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


    public int Speed;

    // 공격 범위
    public int AtkRange;


    // 기본 이동 거리
    public int MoveRange;

    // 기준 위치
    public Vector2 StdVector;



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
        curState?.Enter();
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
                    return;
                }
                else
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
