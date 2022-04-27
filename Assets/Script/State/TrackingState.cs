using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingState : State
{
    int dir;
    bool isCondition;

    public override bool Condition()
    {
        isCondition = Owner.target == null ? false : true;
        if (Owner.anim.GetCurrentAnimatorStateInfo(0).IsName("MonAttack"))
            isCondition = true;
        return isCondition;
    }

    public override void Enter()
    {
        Owner.anim.Play("MonTracking");
    }

    public override void Exit()
    {

    }

    public override void Stay()
    {
        if (!Owner.anim.GetCurrentAnimatorStateInfo(0).IsName("MonAttack"))
        {
            if ((Owner.AtkRange * Owner.AtkRange) >= (Owner.target.transform.position - transform.position).sqrMagnitude)
            {
                Owner.anim.Play("MonAttack");
                StartCoroutine("AttackMotion");
            }
            else
            {
                dir = (Owner.target.transform.position - transform.position).normalized.x > 0 ? 1 : -1;
                Owner.GetComponent<SpriteRenderer>().flipX = dir < 0 ? true : false;
                transform.Translate(dir * Vector2.right * Owner.Speed * 1.5f * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            IDamaged damaged = collision.gameObject.GetComponent<IDamaged>();
            damaged?.Damaged(Owner.atk);
        }
    }

    IEnumerator AttackMotion()
    {
        Vector2 targetPos = (Vector2)Owner.target.transform.position + new Vector2((dir * (Owner.AtkRange)), transform.position.y);
        float t = 0;
        while (true)
        {
            t += Time.deltaTime;
            transform.position = new Vector2(Vector2.Lerp(transform.position, targetPos, t).x, transform.position.y);
            if (t >= 1)
            {
                Owner.anim.Play("MonTracking");
                StopCoroutine("AttackMotion");
            }
            yield return null;
        }
    }
}
