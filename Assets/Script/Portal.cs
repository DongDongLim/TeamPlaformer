using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    Npc Owner;

    GameObject obj;

    private void Awake()
    {
        Owner = GetComponentInParent<Npc>();
        obj = UIMng.instance.uiList["이동"];
        Owner.npcReAction += SceneMove;
    }

    public void SceneMove()
    {
        obj.SetActive(true);
    }

}
