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


    public InventoryUI ui;//인벤토리ui

    public List<ItemData> items = new List<ItemData>();
    public List<ItemData> Skills = new List<ItemData>();
    public int maxSize = 12;//인벤토리 맥스사이즈 12 3x4로 구현예정 <- 

    private void Awake()
    {
        _instance = this;//싱글톤 객체 넣어주기
    }

    private void Update()
    {
        if (Input.GetButtonDown("InventoryUI"))//인벤토리 ui 버튼이 눌리면
        {
            ui.gameObject.SetActive(!ui.gameObject.activeSelf);
            ui.UpdateUI();//UI활성화 하기 앙기모디
        }
    }

    public bool Add(ItemData item)//아이템 추가 함수
    {
        if (items.Count >= maxSize)//아이템 수>=최대소지개수
            return false;//빠꾸

        else
        {
            items.Add(item);//위에서 걸러지지 않았다면 아래 실행함.
            ui.UpdateUI();

            return true;
        }
    }

    public void Remove(ItemData item)//아이템 제거 함수
    {
        items.Remove(item);
        ui.UpdateUI();
    }
}
