using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                                                     //ScriptableObject는 데이터 스토리지로다가 빼주는 역할
public abstract class ItemData : Data//아이템데이터 클래스는 추상클래스이며 스크립터블 오브젝트(스크립터를 오브젝트처럼 보이게함)을 상속받고 있음.
{ 
    public GameObject prefab = null;//기본프리펩

    public abstract void Use();//아이템사용함수(가상함수)

    public void Remove()//아이템 삭제
    {
        InventoryManager.instance.Remove(this);
    }
}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[CreateAssetMenu(fileName = "ItemData", menuName = "Data/ItemData")]
//public class ItemData : Data
//{
//    public GameObject prefab = null;
//}
//아이템 데이터 추상클래스로 구현