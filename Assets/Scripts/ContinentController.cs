using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinentController : MonoBehaviour
{

    public string continentName;

    public ChangeCamera cam;


    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.SelectContinent("africa");
            cam.ToAfricaScreen();
        }
    }

}
