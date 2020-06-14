using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{

    private void Start()
    {
        // TODO: Find this a better place at some point
        ToMainScreen();
    }
    // TODO: call this when starting the game
    public void ToMainScreen()
    {
        Debug.Log("Changed camera view to MainScreen");
        CameraManager.instance.questionScreen.enabled = false;
        CameraManager.instance.continentsScreen.enabled = true;

        UIManager.instance.ClearQuestionBox();

        // TODO: this is still test stuff
        UIManager.instance.testinappi.SetActive(true);
        UIManager.instance.UpdateTitle("Valitse maanosa");
        UIManager.instance.continentTitle.enabled = false;
    }

    public void ToContinentScreen()
    {
        Debug.Log("Changed camera view to QuestionScreen");
        CameraManager.instance.questionScreen.enabled = true;
        CameraManager.instance.continentsScreen.enabled = false;

        // TODO: this is still test stuff
        UIManager.instance.testinappi.SetActive(false);
        UIManager.instance.UpdateTitle("Arvaa valtio");
        UIManager.instance.UpdateContinenTitle("Maanosan nimi");
    }
}
