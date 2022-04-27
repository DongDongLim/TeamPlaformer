using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMng : Singleton<ShopMng>
{
    [SerializeField]
    ItemData[] shopItemData;
    [SerializeField]
    SkillData[] shopSkillData;

    [SerializeField]
    int shopMax;

    [SerializeField]
    int shopMin;

    List<ItemData> listItem = new List<ItemData>();

    List<SkillData> listSkill = new List<SkillData>();

    protected override void OnAwake()
    {

    }

    public void ShopSetting(List<ItemData> item)
    {
        if (listItem.Count == 0)
        {
            for (int i = 0; i < shopItemData.Length; ++i)
            {
                if (Random.Range(0, 2) == 0)
                {
                    item.Add(shopItemData[i]);
                }
                else
                {
                    listItem.Add(shopItemData[i]);
                }
                if (item.Count >= shopMax)
                {
                    listItem.RemoveAll(x => true);
                    return;
                }
            }
        }
        else
        {
            List<ItemData> mini = new List<ItemData>();
            for (int i = 0; i < listItem.Count; ++i)
            {
                if (Random.Range(0, 2) == 0)
                {
                    mini.Add(listItem[i]);
                    item.Add(listItem[i]);
                }
                if (item.Count >= shopMax)
                {
                    listItem.RemoveAll(x => true);
                    return;
                }
            }
            foreach(ItemData data in mini)
            {
                listItem.Remove(data);
            }
        }
        if (item.Count < shopMin)
        {
            ShopSetting(item);
        }
    }


    public void ShopSetting(List<SkillData> item)
    {
        if (listSkill.Count == 0)
        {
            for (int i = 0; i < shopSkillData.Length; ++i)
            {
                if (Random.Range(0, 2) == 0)
                {
                    item.Add(shopSkillData[i]);
                }
                else
                {
                    listSkill.Add(shopSkillData[i]);
                }
                if (item.Count >= shopMax)
                {
                    listSkill.RemoveAll(x => true);
                    return;
                }
            }
        }
        else
        {
            List<SkillData> mini = new List<SkillData>();
            for (int i = 0; i < listSkill.Count; ++i)
            {
                if (Random.Range(0, 2) == 0)
                {
                    mini.Add(listSkill[i]);
                    item.Add(listSkill[i]);
                }
                if (item.Count >= shopMax)
                {
                    listSkill.RemoveAll(x => true);
                    return;
                }
            }
            foreach (SkillData data in mini)
            {
                listSkill.Remove(data);
            }
        }
        if (item.Count < shopMin)
        {
            ShopSetting(item);
        }
    }



}
