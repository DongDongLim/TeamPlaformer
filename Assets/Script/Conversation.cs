using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation
{
    [Header("대화")]
    public string Command;

    public void Say()
    {
        GameObject obj = UIMng.instance.uiList["대화"];
        
        obj.SetActive(true);
    }


   
}
