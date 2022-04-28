using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingState : State
{
    public override bool Condition()
    {
        return Owner.target == null ? false : true;
    }

    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void Stay()
    {
        transform.Translate((Owner.target.transform.position - transform.position).normalized.x * Vector2.right * Owner.Speed * Time.deltaTime);
        if((Owner.AtkRange * Owner.AtkRange) >= (Owner.target.transform.position - transform.position).sqrMagnitude)
        {
            
        }
    }
}
