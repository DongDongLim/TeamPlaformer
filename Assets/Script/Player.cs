using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour , IDamaged
{
    public int Hp = 3;

    bool noDamage;
    float damageDelay;
    bool skillcall;
    float skilltime;


    SceneMng mng;
    public GameObject preFab;

    public Dictionary<string, int> PlayerData = new Dictionary<string, int>();
    
    public void Awake()
    {
        PlayerData.Add("레벨", 2);
        damageDelay = 0;
        noDamage = false;
        skillcall = false;
        skilltime = 0;
    }

    public void Damaged(SkillData data)
    {
        noDamage = true;
        if (!noDamage) { 
            Hp -= data.atk;
        }
        else
        {
            return;
        }
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
        if(Input.GetKeyDown(KeyCode.A))
        {
            if (QuestMng.instance.curQuest.Count != 0)
                QuestMng.instance.curQuest[0].Progress();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayerData["레벨"] = 10;
        }
        if (Input.GetButtonDown("Skill") && skillcall == false)
        {
            skillcall = true;
            GameObject obj = Instantiate(preFab, transform.position, Quaternion.identity);
        }
        
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

        if (skillcall)
        {
            skilltime += Time.deltaTime;
            if (skilltime >= 0.5f)
            {
                skillcall = false;
                skilltime = 0;
            }
        }
    }
}
