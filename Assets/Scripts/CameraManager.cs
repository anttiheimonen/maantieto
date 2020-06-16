using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    private bool inMainScreen;

    private void Awake()
    {
        instance = this;
    }
    public Camera questionScreen;
    public Camera continentsScreen;

    public bool InMainScreen() => inMainScreen;

    public void SetInMainScreen(bool isMainScreenActive)
    {
        inMainScreen = isMainScreenActive;
    }
}
