using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextQuestion : MonoBehaviour
{
    public void GiveHint()
    {
        // TODO: implement
        int questionNumber = RandomNumber();
        // Debug.Log("Randomised hint " + questionNumber);

        UIManager.instance.UpdateQuestion("Hint: " + questionNumber);
    }

    private int RandomNumber()
    {
        System.Random rand = new System.Random();
        int number = rand.Next(100);

        return number;
    }
}
