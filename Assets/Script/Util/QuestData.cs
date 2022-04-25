using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StringInt : SerializableDictionary<string, int> { }

[CreateAssetMenu(fileName = "QuestData", menuName = "Data/QuestData")]
public class QuestData : Data
{
    public string title;

    [TextArea]
    public string description;

    public StringInt Condition;
}
