using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 싱글톤입니다 씬을 전환할 때 사용하시면 됩니다
public class SceneTransform : Singleton<SceneTransform>
{
    IEnumerator iter;
    protected override void OnAwake()
    {

    }

    // 이동할 씬의 이름을 넣어주시면 이동합니다
    // SceneTransform.instance.SceneMove("이름");
    public void SceneMove(string sceneName)
    {
        iter = LoadYourAsyncScene(sceneName);
        StartCoroutine(iter);
    }

    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while(!asyncLoad.isDone)
        {
            yield return null;
        }
        StopCoroutine(iter);
    }

}
