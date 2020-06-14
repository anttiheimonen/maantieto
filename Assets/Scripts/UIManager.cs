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
    public void UpdateTitle(string newTitle)
    {
        title.text = newTitle;
    }

    public void UpdateQuestion(string newQuestion)
    {
        question.text = newQuestion;
    }

    public void UpdateContinenTitle(string newContinentTitle)
    {
        continentTitle.enabled = true;
        continentTitle.text = newContinentTitle;
    }

    public TextMeshProUGUI question;
    public TextMeshProUGUI title;
    public TextMeshProUGUI continentTitle;
    public GameObject testinappi;
}
