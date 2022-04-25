using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "QuestData", menuName = "Data/QuestData")]
public class QuestData : Data
{
    [System.Serializable]
   public enum QuestType
    {
        Collect,
        KillCnt,
        Delivery,
    }
    [SerializeField]
    public QuestType type;

    public Dictionary<string, int> Condition = new Dictionary<string, int>();
}
