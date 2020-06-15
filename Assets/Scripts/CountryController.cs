using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryController : MonoBehaviour
{
    private void OnMouseDown()
    {
        string country = gameObject.name;
        Debug.Log("Valittu maa " + country);
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
        Invoke("ChangeColorToWhite", 1f);
    }


    private void RightCountry()
    {
        ChangeColorToGreen();
        // Invoke("ChangeColorToWhite", 1f);
    }
}
