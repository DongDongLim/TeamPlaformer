using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Npc : MonoBehaviour, IInteraction
{
    public UnityAction npcReAction;

    public void ReAction()
    {
        npcReAction?.Invoke();
    }
}
