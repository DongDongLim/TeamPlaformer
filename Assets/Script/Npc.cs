using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Npc : MonoBehaviour, IInteraction
{
    public UnityAction npcReAction;

    public Conversation basicCon;


    public void Awake()
    {
        npcReAction += basic;
    }

    public void basic()
    {
        basicCon.ReAction();
    }

    public void ReAction()
    {
        npcReAction?.Invoke();
    }


}
