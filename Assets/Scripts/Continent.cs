using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continent : MonoBehaviour
{


    public string continentName;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        // Debug.Log("Mouse is over GameObject.");
        if (Input.GetMouseButtonDown(0))
        {
            gm.SelectContinent("Afrikka");
        }
    }
}
