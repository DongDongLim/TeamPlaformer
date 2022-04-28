using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillItemData", menuName = "Data/SkillItemData")]
public class SkillItemData : ItemData
{
    public SkillData skillData;//어떤 데이터가 들어올지

    public override void Use()// 어떤 아이템인지(버튼을 눌렀을때)
    {
        GameMng.instance.PlayerAttack(this);//UI로써 존재할때 사용
    }

    public SkillData SkillAttack()// 이 아이템에 어떤 스킬이 있는지(몬스터한테 부딫혔을때)
    {
        return skillData;//게임오브젝트로 존재할때 사용 
    }
}
