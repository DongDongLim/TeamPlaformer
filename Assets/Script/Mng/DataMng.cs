using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMng : Singleton<DataMng>
{
    List<Data> itemData = new List<Data>();
    List<Data> skillData = new List<Data>();
    List<Data> QuestData = new List<Data>();

    protected override void OnAwake()
    {

    }  

    public void Add(Data data)
    {
        if(data as ItemData != null)
        {
            itemData.Add(data);
            return;
        }
        else if (data as SkillData != null)
        {
            skillData.Add(data);
            return;
        }
        else if (data as QuestData != null)
        {
            QuestData.Add(data);
            Debug.Log(true);
            return;
        }
        Debug.Log(false);
    }

}
