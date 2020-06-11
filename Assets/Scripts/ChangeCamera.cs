using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{

    private void Awake()
    {
        // ChangeCamera();
    }
    public void ChangeCameraView()
    {
        Debug.Log("Changed camera");
        CameraManager.instance.questionScreen.enabled = false;
        CameraManager.instance.test.enabled = true;
    }
}
