using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropData : ItemData
{
    [System.Serializable]
    public enum DropType
    {
        GOLD,
        QUEST,

    }
    [SerializeField]//인스펙터창에 보여줌
    public DropType droptype;
    public override void Use()
    {
        GameMng.instance.DropItem( 
            Instantiate(prefab, GameMng.instance.transform, false));//게임매니저의 드랍아이템
    }
}
