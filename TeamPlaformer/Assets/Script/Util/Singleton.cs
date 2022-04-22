using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour
{
    private static T _instance;
    public static T instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        OnAwake();
    }

    protected void AddInstance(T t)
    {
        _instance = t;
    }

    public abstract void OnAwake();

}
