using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private ContinentManager cm;


    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        cm = new ContinentManager();
    }


    public void SelectContinent(string continent)
    {
        Debug.Log(continent);
        cm.GetContinentInfo(continent);
    }


    void update()
    {

    }
}
