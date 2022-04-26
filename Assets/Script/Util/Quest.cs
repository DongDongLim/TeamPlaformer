using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest : MonoBehaviour
{
    public QuestData quest;

    public Player player;

    protected Npc Owner;

    public bool isActive;

    protected bool isFinished = false;

    [SerializeField]
    public Conversation accept, progress, complate;

    public int expReward;

    public int goldReward;

    public ItemData itemReward;

    [SerializeField]
    protected Quest NextQuest = null;

    protected virtual void Awake()
    {
        Owner = GetComponentInParent<Npc>();
        Owner.npcReAction += Accept;
        Owner.npcReAction -= Owner.basic;
    }

    public void Accept()
    {
        if(isActive)
        {
            foreach(string i in quest.Condition.Keys)
            {
                if (0 <= quest.Condition[i])
                {
                    if (player.PlayerData[i] < quest.Condition[i])
                    {
                        foreach(Quest quest in Owner.GetComponentsInChildren<Quest>())
                        {
                            if(quest.isActive)
                            {
                                if (this == quest)
                                {
                                    Owner.basic();
                                }
                            }
                        }
                        return;
                    }
                }
            }
            Owner.npcReAction -= Owner.basic;
            Owner.npcReAction -= Accept;
            Owner.npcReAction += accept.ReAction;
            Owner.npcReAction?.Invoke();
            Owner.npcReAction -= accept.ReAction;
            Owner.npcReAction += progress.ReAction;
            QuestMng.instance.QuestStart(this);
        }
        else
        {
            if (isFinished)
            {
                Owner.npcReAction += Owner.basic;
                Owner.npcReAction -= complate.ReAction;
                Owner.npcReAction -= Accept;
                if (null != NextQuest)
                    NextQuest.isActive = true;
                QuestMng.instance.QuestComplete(this);
            }
            else
            {
                foreach (Quest quest in Owner.GetComponentsInChildren<Quest>())
                {
                    if (quest.isActive)
                    {
                        return;
                    }
                }
                if (this == Owner.GetComponentInChildren<Quest>())
                    Owner.basic();
            }
        }
    }

    public abstract void Progress();

    public abstract void Complete();






}
