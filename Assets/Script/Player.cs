using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour , IDamaged
{
    public int Hp = 3;

    bool noDamage;
    float damageDelay;
   
    SceneMng mng;
    Rigidbody2D rigid;

    public Dictionary<string, int> PlayerData = new Dictionary<string, int>();
    
    public void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        PlayerData.Add("레벨", 2);
        damageDelay = 0;
        noDamage = false;
       
    }

    public void Damaged(SkillData data)
    {
        rigid.AddForce(new Vector2(-100f, 100f), ForceMode2D.Impulse);
        noDamage = true;
       /* if (!noDamage && data.SkillType == curType.SkillType.NOMMAL) { 

            Hp -= data.atk;
        }
        else if(!noDamage && data.atk == SkillData.SkillType.STUN)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
            rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        else if(!noDamage && SkillData.SkillType.INSTANTKILL)
        {
            Die();
        }*/
      

        if (Hp <= 0)
        {
            //Die();
        }

    }

    private void Die()
    {
        //mng.SceneEnter();
    }
    private void FixedUpdate()
    {
       Delay();
    }



    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.DrawRay(transform.position, Vector2.right * 10f, new Color(0, 1, 0));
            RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.right, 10f, LayerMask.GetMask("NPC"));
            if (null != ray.collider)
            {
                IInteraction target = ray.collider.GetComponent<IInteraction>();
                if (null != target)
                {
                    target.ReAction();
                    return;
                }
            }
        }
        /*if(Input.GetKeyDown(KeyCode.A))
        {
            if (QuestMng.instance.curQuest.Count != 0)
                QuestMng.instance.curQuest[0].Progress();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayerData["레벨"] = 10;
        }*/
    }
    private void Delay()
    {
        if (noDamage)
        {
            damageDelay += Time.deltaTime;
            if (damageDelay >= 0.6f)
            {
                noDamage = false;
                damageDelay = 0;
            }
        }
    }
}
