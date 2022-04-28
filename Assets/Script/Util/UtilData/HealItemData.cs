using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealItem", menuName = "Data/HealItem")]
public class HealItemData : ItemData //힐아이템 <- 데이터 데이터면 데이터를 가지고 있어야 함
{
    public int HealPoint;//체력 회복량 

    public override void Use()
    {
        GameMng.instance.playerHp += HealPoint;//게임매니저의 플레이어 HP에 처리 하기
        if (GameMng.instance.playerHp > GameMng.instance.MaxHp)//처리 했는데 MaxHp이랑 같거나 커 
        {
            GameMng.instance.playerHp = GameMng.instance.MaxHp;//그러면 그냥 MaxHp을만듬
        }
    }
}
