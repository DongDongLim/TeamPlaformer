using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMng : Singleton<QuestMng>
{

    public List<Quest> curQuest = new List<Quest>();

    protected override void OnAwake()
    {

    }
    public void QuestStart(Quest quest)
    {
        Debug.Log("퀘스트 시작");
        Debug.Log("퀘스트 이름 : " + quest.quest.title);
        Debug.Log("퀘스트 설명 : " + quest.quest.description);
        curQuest.Add(quest);
    }

    public void QuestComplete(Quest quest)
    {
        Debug.Log("퀘스트 완료");
        Debug.Log("퀘스트 보상 골드 : " + quest.goldReward);
        Debug.Log("퀘스트 보상 경험치 : " + quest.expReward);
        curQuest.Remove(quest);
    }
}
