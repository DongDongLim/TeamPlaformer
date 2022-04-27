using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUnit : MonoBehaviour//대충 인벤토리 유닛?아이콘? 클래스
{
    public Button button;//UI의 버튼을 가져옴
    public Image icon;//UI로 쓸 아이콘 이미지를 가져옴 

    ItemData curItemData;//현재 아이템 정보를 담을 변수

    public void AddItem(ItemData itemData)//아이템 추가 함수
    {
        curItemData = itemData;//들어온 아이템 데이터 만든 변수에 넣기

        icon.sprite = itemData.icon;//아이콘 스프라이트 
        icon.enabled = true;//아이콘 활성화
        button.interactable = true;
    }

    public void RemoveItem()//아이템 제거 함수
    {
        curItemData = null;//모든값 널,false로 만들

        icon.sprite = null;
        icon.enabled = false;
        button.interactable = false;
    }

    public void UseItem()
    {
        //TODO:아이템 사용하는 애니메이션 등 연결...
        curItemData.Use();//아이템 사용하기
    }
}