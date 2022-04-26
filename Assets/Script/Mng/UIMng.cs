using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMng : Singleton<UIMng>
{
    public Dictionary<string, GameObject> uiList = new Dictionary<string, GameObject>();

    [SerializeField]
    GameObject[] uiDialog;

    protected override void OnAwake()
    {
        uiList.Add("대화", uiDialog[0]);
        uiList.Add("대화1", uiDialog[0]);
    }
}
