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

    public TextMeshProUGUI questionBox;
    public GameObject testinappi;

    public void ClearQuestionBox()
    {
        questionBox.text = "";
        Debug.Log("Cleared questionbox");
    }
}
