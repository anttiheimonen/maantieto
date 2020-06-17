using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryController : MonoBehaviour
{
    private Vector3 mouseOverScale = new Vector3(1.2f, 1.2f, 1.2f);
    private bool mouseOver;
    private Color originalColor;
    private bool answered;

    private void OnMouseDown()
    {
        string country = gameObject.name;
        // Debug.Log("Valittu maa " + country);
        GameManager.Instance.SelectCountry(country);
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;
        // Debug.Log("Clicked " + gameObject.name);
        // TODO: fix at some point
    }


    private void OnMouseOver()
    {
        if (!answered)
        {
            if (!mouseOver)
            {
                mouseOver = true;
                originalColor = gameObject.GetComponent<SpriteRenderer>().color;
            }
            gameObject.transform.localScale = mouseOverScale;
            gameObject.GetComponent<SpriteRenderer>().color
                = gameObject.GetComponent<SpriteRenderer>().color
                * new Color(0.96f, 0.96f, 0.96f, 1f);
        }
    }


    private void OnMouseExit()
    {
        mouseOver = false;
        gameObject.transform.localScale = Vector3.one;
        // originalColor = gameObject.GetComponent<SpriteRenderer>().color;
        ChangeColorTo(originalColor);
    }


    public void ClearColorCoding()
    {
        ChangeColorToWhite();
        SetAnswered(false);
        originalColor = Color.white;
    }


    public void AnswerIs(bool answer)
    {
        if (answer)
            RightCountry();
        else
            WrongCountry();
    }

    private void ChangeColorToYellow()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
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


    private void ChangeColorTo(Color color)
    {
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }


    public void SetAnswered(bool value)
    {
        answered = value;
    }


    private void WrongCountry()
    {
        answered = true;
        // originalColor = Color.red;
        ChangeColorToRed();
        UIManager.instance.UpdateAnswerFeedBack("Väärin");
        GameManager.Instance.GetComponent<SoundController>().PlaySound(SoundManager.instance.wrongAnswer);
        // Invoke("ChangeColorToWhite", 1f);
    }


    private void RightCountry()
    {
        answered = true;
        // originalColor = Color.green;
        ChangeColorToGreen();
        UIManager.instance.UpdateAnswerFeedBack("Oikein!");
        GameManager.Instance.GetComponent<SoundController>().PlaySound(SoundManager.instance.rightAnswer);

        // Invoke("ChangeColorToWhite", 3f);
    }
}
