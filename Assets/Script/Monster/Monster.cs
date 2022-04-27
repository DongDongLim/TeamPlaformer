using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IDamaged
{
    public int HP = 5;
    public void Damaged(SkillData data)
    {
        HP -= data.atk;
        //if(HP)
    }
}
