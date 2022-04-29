using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    [SerializeField]
    Button[] btn;

    private void OnEnable()
    {
        for(int i = 0; i < 3; ++i)
        {
            if(btn[i].gameObject.GetComponentInChildren<Text>().text == SceneMng.instance.curScnen.name)
                btn[i].interactable = false;
            else
                btn[i].interactable = true;
        }
    }

    public void Stage1()
    {
        SceneMng.instance.SceneMove("Stage1");
    }

    public void Stage2()
    {
        SceneMng.instance.SceneMove("Stage2");
    }

    public void Stage3()
    {
        SceneMng.instance.SceneMove("Stage3");
    }
}
