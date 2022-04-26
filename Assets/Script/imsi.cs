using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imsi : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (SceneMng.instance.curScnen.name == "Title")
                SceneMng.instance.SceneMove("Stage1");
            else
                SceneMng.instance.SceneMove("Title");
        }


    }
}
