using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //정보또한 아이템에서 가지고 있음.

    public ItemData data;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            IDamaged damaged = other.gameObject.GetComponent<IDamaged>();
            damaged.Damaged((data as SkillItemData)?.SkillAttack());
            //TODO: 위치에 파티클생성 파티클이 스크립트 안에서도 가지고 있을것 변수 스크립트 안에 스킬데이터든 뭐든 퍼블릭
        }
        if (other.gameObject.layer==LayerMask.NameToLayer("Player"))
        {
            if(null != data as DropData)
            {
                if ((data as DropData).droptype == DropData.DropType.QUEST)
                    InventoryManager.instance.Add(data);
                else
                    GameMng.instance.Gold += 10;
                Destroy(gameObject);
            }
        }
    }
}

//data.Use();
//(data as SkillItemData)?.SkillAttack();