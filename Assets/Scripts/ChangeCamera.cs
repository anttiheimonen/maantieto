using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    private bool startDone = false;

    private void Start()
    {
        // TODO: Find this a better place at some point
        ToMainScreen();
        startDone = true;
    }
    public void ToMainScreen()
    {
        // Changes camera view point
        // Debug.Log("Changed camera view to MainScreen");
        CameraManager.instance.questionScreen.enabled = false;
        CameraManager.instance.continentsScreen.enabled = true;
        CameraManager.instance.SetInMainScreen(true);

        UIManager.instance.ClearQuestionBox();
        UIManager.instance.ClearAnswerFeedBack();
        UIManager.instance.starBar.gameObject.SetActive(false);

        // Deactivates game view title
        // UIManager.instance.gameViewTitle.enabled = false;
        UIManager.instance.btnNextQuestion.SetActive(false);
        UIManager.instance.testinappi.SetActive(true);

        UIManager.instance.UpdateUiTitle("Valitse maanosa");
        UIManager.instance.UpdateGameViewTitle("Maailmankartta");

        PlaySound();
    }

    public void ToAfricaScreen()
    {
        // Changes camera view point
        // Debug.Log("Changed camera view to QuestionScreen");
        UIManager.instance.ClearAnswerFeedBack();

        CameraManager.instance.questionScreen.enabled = true;
        CameraManager.instance.continentsScreen.enabled = false;
        CameraManager.instance.SetInMainScreen(false);

        UIManager.instance.btnNextQuestion.SetActive(true);
        UIManager.instance.testinappi.SetActive(false);
        UIManager.instance.starBar.gameObject.SetActive(true);

        UIManager.instance.UpdateUiTitle("Arvaa valtio");
        UIManager.instance.UpdateGameViewTitle("Afrikka");

        PlaySound();
    }

    private void PlaySound()
    {
        if (startDone)
        {
            // GameManager.Instance.GetComponent<AudioSource>().PlayOneShot(SoundManager.instance.changeCamera);
            GameManager.Instance.GetComponent<SoundController>().PlaySound(SoundManager.instance.changeCamera);
        }
    }


    public void ReturnButtonLogic()
    {
        if (!CameraManager.instance.InMainScreen())
        {
            ToMainScreen();
        }
        else
        {
            Debug.Log("Quitting");
            Application.Quit();
        }
    }

}
