using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectQuest : Quest
{
    int curAmount;

    [SerializeField]
    int maxAmount;
    protected override void Awake()
    {
        base.Awake();
        curAmount = 0;
    }

    public override void Progress()
    {
        ++curAmount;
        if(maxAmount == curAmount)
        {
            Complete();
        }
    }
    public override void Complete()
    {
        isActive = false;
        isFinished = true;
        Owner.npcReAction -= progress.ReAction;
        Owner.npcReAction += complate.ReAction;
        Owner.npcReAction += Accept;
    }

}
