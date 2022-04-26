using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IDamaged
{
    [SerializeField]
    ItemData[] dropItem;

    [SerializeField]
    float Hp;

    [SerializeField]
    int Atk;

    [SerializeField]
    int Speed;

    public void Damaged(SkillData data)
    {
        
        Hp -= data.atk;
        if (Hp <= 0)
            Die();
    }

    void Die()
    {
        GameMng.instance.RemoveObj(gameObject);
    }

}
