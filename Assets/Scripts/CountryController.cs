using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryController : MonoBehaviour
{
    private Vector3 mouseOverScale = new Vector3(1.2f, 1.2f, 1.2f);

    private void OnMouseDown()
    {
        string country = gameObject.name;
        // Debug.Log("Valittu maa " + country);
        GameManager.Instance.SelectCountry(country);
        // Debug.Log("Clicked " + gameObject.name);
        // TODO: fix at some point
    }


    private void OnMouseOver()
    {
        // Debug.Log("JEE");
        gameObject.transform.localScale = mouseOverScale;
        // ChangeColorToYellow();
        gameObject.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color
                                                        + new Color(20, 20, 20, 0);
    }


    private void OnMouseExit()
    {
        gameObject.transform.localScale = Vector3.one;
        ChangeColorToWhite();
    }


    public void ClearColorCoding()
    {
        ChangeColorToWhite();
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
