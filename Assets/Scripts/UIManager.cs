using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }


    public void ClearQuestionBox()
    {
        question.text = "";
        Debug.Log("Cleared questionbox");
    }
    public void UpdateUiTitle(string newTitle)
    {
        uiTitle.text = newTitle;
    }

    public void UpdateQuestion(string newQuestion)
    {
        question.text = newQuestion;
    }

    public void UpdateGameViewTitle(string newContinentTitle)
    {
        gameViewTitle.enabled = true;
        gameViewTitle.text = newContinentTitle;
    }

    public TextMeshProUGUI question;
    public TextMeshProUGUI uiTitle;
    public TextMeshProUGUI gameViewTitle;
    public GameObject testinappi;
    public GameObject btnNextQuestion;
}
