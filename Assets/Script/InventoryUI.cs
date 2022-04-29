using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TODO:인벤토리유아이 분석할것
public class InventoryUI : MonoBehaviour
{
    public int num;

    InventoryUnit[] items;//인벤토리에 담을 아이템들(인벤토리유닛 클래스 참조)


    private void Awake()
    {

    }

    public void UpdateUI()//대충 요약하면 모든 아이템들 업데이트 하는 함수
    {
        items = GetComponentsInChildren<InventoryUnit>();//인벤토리 유닛 아래로(자식으로)있는 컴퍼넌트 가져와서 아이템즈에 넣기
        for (int i = 0; i < items.Length; i++)//아이템즈 길이만큼
        {
            if (i < InventoryManager.instance.items[num].Count)//인벤토리 매니저한테 아이템 갯수 세달라해서  
            {
                items[i].AddItem(InventoryManager.instance.items[num][i]);//아이템 추가하기
            }
            else
            {
                items[i].RemoveItem();
            }
        }
    }
}
