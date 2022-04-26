using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{
    [Header("대화")]
    public string Command;//대화 내용... 텍스트를 불러와서 커맨드를 넣어주면 원하는 대화가 된다.

    public void ReAction()
    {
        GameObject obj = UIMng.instance.uiList["대화"];//"대화"라는 얘의 값이 불러와지면
        obj.GetComponentInChildren<Text>().text = Command;
        //Debug.Log(Command);//이 로그를 실행
        obj.SetActive(true);//창을 활성화 시킨다 오브젝트가 널이 아닐경우에 활성화..식으로 ex 대화창이 없는 경우
    }


   
}
