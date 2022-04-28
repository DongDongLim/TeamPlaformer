using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Data : ScriptableObject
{
    new public string name = "Data Name";

    public Sprite icon = null;

    public float CoolTime = 0.5f;

}
