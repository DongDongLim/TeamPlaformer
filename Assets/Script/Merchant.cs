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
        AddItem();
        Owner.npcReAction += DataRead;
    }

    public void AddItem()
    {
        foreach (ItemData data in itemDatas)
            InventoryManager.instance.Add(data, 0);
    }

    public void DataRead()
    {
        InventoryManager.instance.InventoryActive(0);
        InventoryManager.instance.InventoryActive(1);
    }
}
