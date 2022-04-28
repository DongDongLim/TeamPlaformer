using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override void Enter()
    {
        Owner.anim.Play("MonWalk");
    }

    public override void Exit()
    {

    }

    public override void Stay()
    {
        transform.Translate(Vector2.right * Owner.Speed * Time.deltaTime);
    }

    public override bool Condition()
    {
        return true;
    }
}
