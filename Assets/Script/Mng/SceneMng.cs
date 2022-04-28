using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

// 싱글톤입니다 씬을 전환할 때 사용하시면 됩니다
public class SceneMng : Singleton<SceneMng>
{
    IEnumerator iter;

    // 씬에 진입할때 이벤트
    // 가능하면 매니저에서 추가를 권장드립니다
    // 추가하는 함수는 string매개변수를 가지고 있어야 하며
    // 이 string 매개변수는 Scene이름이 들어올 예정이니 특정 씬의 이벤트일때 활용하시면 됩니다
    // 어떤 씬이던 상관 없이 일어나야하는 이벤트라면 매개변수를 string으로 가지고 있되
    // 실제 내용에서 활용을 안하시면 됩니다
    public UnityAction<string> SceneEnter;

    // 씬에서 빠져 나올때 이벤트
    // 위 이벤트와 내용 동일
    public UnityAction<string> SceneExit;

    // 현재 씬
    // SceneMng.instance.curScnen.name 등으로 현재 씬의 정보를 받을 수 있습니다
    public Scene curScnen;

    protected override void OnAwake()
    {
        curScnen = SceneManager.GetActiveScene();

        /* 사용 예시
        SceneEnter += SceneName;
        SceneEnter += Stage1Scene;

        SceneExit += SceneName;
        */
    }

    /* 사용 예시
    void SceneName(string name)
    {
        Debug.Log(name);
    }
    
    void Stage1Scene(string name)
    {
        if(name == "Stage1")
            Debug.Log("배틀 시작!");
    }
    */

    // 이동할 씬의 이름을 넣어주시면 이동합니다
    // SceneMng.instance.SceneMove("이름");
    public void SceneMove(string sceneName)
    {
        iter = LoadYourAsyncScene(sceneName);
        StartCoroutine(iter);
    }

    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        SceneExit?.Invoke(curScnen.name);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        curScnen = SceneManager.GetActiveScene();
        SceneEnter?.Invoke(sceneName);
        StopCoroutine(iter);
    }



    private void Update()
    {
        if(curScnen.name != "Stage2")
        if(Input.GetButtonDown("Jump"))
        {
            SceneMove("Stage2");
        }
    }
}
