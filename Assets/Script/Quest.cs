using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{


    private void Awake()
    {
        GetComponentInParent<Npc>().npcReAction += QuestStart;
    }

    public void QuestStart()
    {

    }
}
