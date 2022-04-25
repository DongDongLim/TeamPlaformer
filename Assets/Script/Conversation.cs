using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{
    [Header("대화")]
    public string Command;

    public void ReAction()
    {
        //GameObject obj = UIMng.instance.uiList["대화"];
        Debug.Log(Command);
        //obj.SetActive(true);
    }


   
}
