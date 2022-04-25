using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMng : Singleton<UIMng>
{
    public Dictionary<string, GameObject> uiList = new Dictionary<string, GameObject>();
    protected override void OnAwake()
    {

    }
}
