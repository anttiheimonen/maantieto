using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryController : MonoBehaviour
{
    private void OnMouseDown()
    {
        string country = gameObject.name;
        // Debug.Log("Valittu maa " + country);
        GameManager.Instance.SelectCountry(country);
        // Debug.Log("Clicked " + gameObject.name);
        // TODO: fix at some point
        if (gameObject.name == "egypt")
        {
            RightCountry();
            return;
        }
        WrongCountry();
    }


    public void ClearColorCoding()
    {
        ChangeColorToWhite();
    }


    private void ChangeColorToRed()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }


    private void ChangeColorToWhite()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }


    private void ChangeColorToGreen()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }


    private void WrongCountry()
    {
        ChangeColorToRed();
        UIManager.instance.UpdateAnswerFeedBack("Väärin");
        GameManager.Instance.GetComponent<SoundController>().PlaySound(SoundManager.instance.wrongAnswer);
        // Invoke("ChangeColorToWhite", 1f);
    }


    private void RightCountry()
    {
        ChangeColorToGreen();
        UIManager.instance.UpdateAnswerFeedBack("Oikein!");
        GameManager.Instance.GetComponent<SoundController>().PlaySound(SoundManager.instance.rightAnswer);

        // Invoke("ChangeColorToWhite", 3f);
    }
}
