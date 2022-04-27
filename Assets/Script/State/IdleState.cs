using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    float t = 0;

    int dir = 1;
    public override void Enter()
    {
        Owner.anim.Play("MonWalk");
        Owner.StdVector = transform.position;
        t = 0.5f;
        dir = 1;
    }

    public override void Exit()
    {
    }

    public override void Stay()
    {
        t += Time.deltaTime * dir * Owner.Speed / 10;
        transform.position = new Vector2( Vector2.Lerp(Owner.StdVector + new Vector2(Owner.MoveRange, transform.position.y)
            , Owner.StdVector - new Vector2(Owner.MoveRange, transform.position.y), t).x, transform.position.y);
        if (t >= 1)
            t = 1;
        else if (t <= 0)
            t = 0;
        if (t <= 0 || t >= 1)
            dir *= -1;
        Owner.GetComponent<SpriteRenderer>().flipX = dir < 0 ? false : true;
    }

    public override bool Condition()
    {
        return true;
    }
}
