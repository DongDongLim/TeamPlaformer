using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : Singleton<GameMng>
{
    [SerializeField]
     GameObject MonPrefab1;

    List<GameObject> popList = new List<GameObject>();

    ObjectPooing pooling = new ObjectPooing();

    int poolingCount = 10;

    protected override void OnAwake()
    {
        pooling.OnRePooing += PooingObj;
        SceneMng.instance.SceneEnter += SummonMon;
        SceneMng.instance.SceneExit += DeleteMon;

        pooling.OnRePooing?.Invoke();
    }

    void SummonMon(string name)
    {
        if(name == "Stage2")
        {
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
        obj.transform.localPosition = new Vector3(0, -3.2f, 0);
        obj.SetActive(true);
        popList.Add(obj);
    }

    public void RemoveObj(GameObject obj)
    {
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
}
