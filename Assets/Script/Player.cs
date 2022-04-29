using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Dictionary<string, int> PlayerData = new Dictionary<string, int>();

    public void Awake()
    {
        PlayerData.Add("레벨", 2);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if (QuestMng.instance.curQuest.Count != 0)
                QuestMng.instance.curQuest[0].Progress();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayerData["레벨"] = 10;
        }
    }
}
