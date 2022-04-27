using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour , IDamaged
{
    public int Hp = 3;

    SceneMng mng;

    public Dictionary<string, int> PlayerData = new Dictionary<string, int>();
    
    public void Awake()
    {
        PlayerData.Add("레벨", 2);
    }

    public void Damaged(SkillData data)
    {
        Hp -= data.atk;
        if(Hp <= 0)
        {
            //Die();
        }
    }

    private void Die()
    {
        //mng.SceneExit();
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
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if (QuestMng.instance.curQuest.Count != 0)
                QuestMng.instance.curQuest[0].Progress();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayerData["레벨"] = 10;
        }
        
    }
}
