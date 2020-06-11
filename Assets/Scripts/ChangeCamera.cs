using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public void ToMainScreen()
    {
        Debug.Log("Changed camera view to MainScreen");
        CameraManager.instance.questionScreen.enabled = false;
        CameraManager.instance.test.enabled = true;

        UIManager.instance.ClearQuestionBox();

        // TODO: this is still test stuff
        UIManager.instance.testinappi.SetActive(true);

    }

    public void ToQuestionScreen()
    {
        Debug.Log("Changed camera view to QuestionScreen");
        CameraManager.instance.questionScreen.enabled = true;
        CameraManager.instance.test.enabled = false;

        // TODO: this is still test stuff
        UIManager.instance.testinappi.SetActive(false);
    }
}
