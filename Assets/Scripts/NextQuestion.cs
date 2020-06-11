using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextQuestion : MonoBehaviour
{
    public void GiveQuestion()
    {
        // TODO: implement
        int questionNumber = RandomNumber();
        Debug.Log("Randomised question " + questionNumber);

        UIManager.instance.questionBox.text = "Question: " + questionNumber;
    }

    private int RandomNumber()
    {
        System.Random rand = new System.Random();
        int number = rand.Next(100);

        return number;
    }
}
