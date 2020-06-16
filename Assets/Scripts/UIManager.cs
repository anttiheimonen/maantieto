using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI hint;

    public TextMeshProUGUI uiTitle;

    public TextMeshProUGUI gameViewTitle;

    public TextMeshProUGUI answerFeedback;

    public GameObject testinappi;

    public GameObject btnNextQuestion;
    public GameObject stars;

    private string hintLineChange = "";


    private void Awake()
    {
        instance = this;
    }


    public void RightAnswer(string country)
    {
        UpdateQuestion(country + " on oikea vastaus!");
    }


    public void WrongAnswer(string country)
    {
        UpdateQuestion(country + " ei ole oikea vastaus!");
    }


    public void ClearQuestionBox()
    {
        hint.text = "";
        hintLineChange = "";

        // Debug.Log("Cleared questionbox");
    }


    public void UpdateUiTitle(string newTitle)
    {
        uiTitle.text = newTitle;
    }


    public void UpdateQuestion(string newHint)
    {
        hint.text = hint.text + hintLineChange + newHint;
        hintLineChange = "\n";
    }


    public void UpdateGameViewTitle(string newContinentTitle)
    {
        gameViewTitle.enabled = true;
        gameViewTitle.text = newContinentTitle;
    }


    public void UpdateAnswerFeedBack(string newFeedBack)
    {
        answerFeedback.text = newFeedBack;
    }


    public void ClearAnswerFeedBack()
    {
        UpdateAnswerFeedBack("");
    }

}
