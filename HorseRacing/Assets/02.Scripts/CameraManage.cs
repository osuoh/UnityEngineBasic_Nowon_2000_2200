using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManage : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private Camera playerFollowingCam;


    private void Awake()
    {
        mainCam.enabled = true;
        playerFollowingCam.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            SwitchCam();
    }

    private void SwitchCam()
    { 
        mainCam.enabled = !mainCam.enabled;
        playerFollowingCam.enabled = !playerFollowingCam.enabled;
    }
}
