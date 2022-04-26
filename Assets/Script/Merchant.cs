using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    Npc Owner;

    List<ItemData> itemDatas = new List<ItemData>();
    private void Awake()
    {
        Owner = GetComponentInParent<Npc>();

        ShopMng.instance.ShopSetting(itemDatas);

        Owner.npcReAction += DataRead;
    }

    public void DataRead()
    {
        foreach (ItemData data in itemDatas)
            Debug.Log(data.name);

    }
}
