using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{
    [Header("대화")]
    public string Command;//대화 내용... 텍스트를 불러와서 커맨드를 넣어주면 원하는 대화가 된다.

    GameObject obj;

    private void Awake()
    {
        obj = UIMng.instance.uiList["대화"];
    }

    public void ReAction()
    {
        if (!obj.activeSelf)
        {
            obj.GetComponentInChildren<Text>().text = Command;
            //Debug.Log(Command);//이 로그를 실행
            obj.SetActive(true);//창을 활성화 시킨다 오브젝트가 널이 아닐경우에 활성화..식으로 ex 대화창이 없는 경우
            Invoke("Action", 0.2f);
        }
    }

    void Action()
    {
        StartCoroutine("ConversationUI");
    }

    IEnumerator ConversationUI()
    {
        Time.timeScale = 0;
        while (true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                obj.SetActive(false);
                Time.timeScale = 1;
                StopCoroutine("ConversationUI");
            }
            yield return null;
        }
    }


   
}
