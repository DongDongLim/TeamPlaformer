using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _instance;//아이템 매니저 싱글톤으로 구현!
    public static InventoryManager instance
    {
        get
        {
            return _instance;
        }
    }


    public InventoryUI[] ui;//인벤토리ui


    public List<ItemData>[] items = new List<ItemData>[2];
    public List<ItemData>[] Skills = new List<ItemData>[2];
    public int maxSize = 15;

    private void Awake()
    {
        _instance = this;//싱글톤 객체 넣어주기

    }

    private void Start()
    {
        items[0] = new List<ItemData>();
        items[1] = new List<ItemData>();
        Skills[0] = new List<ItemData>();
        Skills[1] = new List<ItemData>();

    }

    private void Update()
    {
        if (Input.GetButtonDown("InventoryUI"))//인벤토리 ui 버튼이 눌리면
        {
            InventoryActive(1);
        }
    }

    public void InventoryActive(int i)
    {
        ui[i].gameObject.SetActive(!ui[i].gameObject.activeSelf);
        ui[i].UpdateUI();//UI활성화 하기 앙기모디
    }

    public bool Add(ItemData item, int i)//아이템 추가 함수
    {
        if (items[i].Count >= maxSize)//아이템 수>=최대소지개수
            return false;//빠꾸
        //Debug.Log("")//
        else
        {
            items[i].Add(item);//위에서 걸러지지 않았다면 아래 실행함.

            ui[i].UpdateUI();

            return true;
        }
    }

    public void Remove(ItemData item, int i)//아이템 제거 함수
    {
        items[i].Remove(item);
        ui[i].UpdateUI();
    }
}
