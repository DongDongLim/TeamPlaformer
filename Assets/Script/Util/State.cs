using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected Monster Owner;

    public void SetOwner(Monster monster)
    {
        Owner = monster;
    }

    public abstract bool Condition();

    public abstract void Enter();

    public abstract void Exit();

    public abstract void Stay();

}
