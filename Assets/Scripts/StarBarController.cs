using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarBarController : MonoBehaviour
{
    public Slider slider;


    public void AddScore(int score)
    {
        slider.value = score;
    }


    public void Initialize(int currentScore, int maxScore)
    {
        slider.value = currentScore;
        slider.maxValue = maxScore;
    }


    public void SetScore(int score)
    {
        if (score < 0)
            return;

        if (score > slider.maxValue)
            slider.value = slider.maxValue;
        else
            slider.value = score;
    }

}
