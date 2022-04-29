using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIMng : Singleton<UIMng>
{
    public Dictionary<string, GameObject> uiList = new Dictionary<string, GameObject>();
       

    [SerializeField]
    GameObject[] uiDialog;

    [SerializeField]
    Canvas mainCanvas;

    protected override void OnAwake()
    {
        uiList.Add("대화", uiDialog[0]);
        uiList.Add("게임시작", uiDialog[1]);
        uiList.Add("상점", uiDialog[2]);
        uiList.Add("인벤토리", uiDialog[3]);
        uiList.Add("이동", uiDialog[4]);
        uiList.Add("페이드인", uiDialog[5]);
        uiList.Add("페이드아웃", uiDialog[6]);
        uiList["상점"].SetActive(false);
        uiList["인벤토리"].SetActive(false);
        uiList["이동"].SetActive(false);
        uiList["페이드인"].SetActive(false);
        uiList["페이드아웃"].SetActive(false);
        SceneMng.instance.SceneExit += UIClose;
        SceneMng.instance.SceneEnter += SetMainCamera;
    }

    public bool isFaidIn = false;
    public bool isFaidOut = false;

    public void FaidIn()
    {
        uiList["페이드인"].SetActive(true);
    }

    public void FaidOut()
    {
        uiList["페이드아웃"].SetActive(true);
    }

    public void UIClose(string sceneName)
    {
        Time.timeScale = 1;
        isFaidOut = false;
        uiList["페이드아웃"].SetActive(false);
        if(sceneName == "Title")
        {
            uiList["게임시작"].SetActive(false);
        }
        uiList["대화"].SetActive(false);
        uiList["상점"].SetActive(false);
        uiList["인벤토리"].SetActive(false);
        uiList["이동"].SetActive(false);
    }

    public void SetMainCamera(string name)
    {
        isFaidIn = false;
        mainCanvas.worldCamera = Camera.main;
    }

}
