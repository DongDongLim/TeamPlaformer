using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : Singleton<GameMng>
{
    public GameObject player;

    public Dictionary<string, int> PlayerData = new Dictionary<string, int>();



    [SerializeField]
     GameObject MonPrefab1;

    List<GameObject> popList = new List<GameObject>();

    ObjectPooing pooling = new ObjectPooing();

    public float playerHp;

    public int Gold;

    public Vector2 dropPos;

    public float MaxHp = 3;
    

    int poolingCount = 10;

    protected override void OnAwake()
    {
        playerHp = MaxHp;
        pooling.OnRePooing += PooingObj;
        SceneMng.instance.SceneEnter += SummonMon;
        SceneMng.instance.SceneExit += DeleteMon;

        pooling.OnRePooing?.Invoke();
    }

    void SummonMon(string name)
    {
        if(name == "Stage2")
        {
            player.SetActive(true);
            CreateObj();
            //for (int i = 0; i < 10; ++i)
            //{
            //    CreateObj();
            //}
        }
    }

    void DeleteMon(string name)
    {
        if (name == "Stage2")
        {
            RemoveAllObj();
        }
    }

    private void Update()
    {

    }

    void PooingObj()
    {
        for (int i = 0; i < poolingCount; ++i)
        {
            pooling.Push(Instantiate(MonPrefab1, this.transform, false));
        }
    }

    public void CreateObj()
    {
        GameObject obj = pooling.Pop(transform.position);
        obj.SetActive(true);
        popList.Add(obj);
    }

    public void RemoveObj(GameObject obj)
    {
        dropPos = obj.transform.position;
        pooling.Push(obj);
        popList.Remove(obj);
    }

    void RemoveAllObj()
    {
        int cnt = popList.Count;
        for (int i = 0; i < cnt; ++i)
            RemoveObj(popList[0]);
    }
    void DamageAllObj()
    {
        //TODO:MonsterScript 완성시 광역데미지 추가
    }
    public void PlayerAttack(SkillItemData Effect)
    {
        //TODO:플레이어 쪽에서 들어온 스킬 이펙트에 대한 처리
    }

    public void DropItem(GameObject item)
    {
        item.transform.position = dropPos;
    }

}
