using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowPlayer : MonoBehaviour
{
    CinemachineVirtualCamera chiCam;

    private void Start()
    {
        chiCam = GetComponent<CinemachineVirtualCamera>();
        chiCam.Follow = GameMng.instance.player.transform;
    }


}
