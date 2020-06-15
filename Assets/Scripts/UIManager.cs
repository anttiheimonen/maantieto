using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private string hintLineChange = "";

    private void Awake()
    {
        instance = this;
    }


    public void RightAnswer(string country)
    {
        Debug.Log("Oikea vastaus " + country);
    }


    public void WrongAnswer(string country)
    {
        Debug.Log("Väärä vastaus " + country);
    }


    public void ClearQuestionBox()
    {
        hint.text = "";
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

    public TextMeshProUGUI hint;
    public TextMeshProUGUI uiTitle;
    public TextMeshProUGUI gameViewTitle;
    public GameObject testinappi;
    public GameObject btnNextQuestion;
}
