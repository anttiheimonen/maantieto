using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private ContinentManager cm;

    private string selectedContinent;

    private GameState gamestate;


    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Debug.Log("luodaan GM instanssi");
            Instance = this;
            // cm = new ContinentManager();
            gamestate = GameState.WorldMap;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        Debug.Log("TUHOITAAN GM instanssi");
    }

    void Start()
    {
        cm = new ContinentManager(); // gameObject.AddComponent(typeof(ContinentManager)) as ContinentManager;
        Debug.Log(cm.Debugaa());
    }


    public void SelectContinent(string tag)
    {
        Debug.Log(tag);
        selectedContinent = tag;
        cm.LoadContinentData(tag);
        gamestate = GameState.ContinentMap;
        if (gamestate == GameState.ContinentMap)
        {
            Debug.Log("jee");
        }
    }


    public void SelectCountry(string tag)
    {
        Debug.Log("Country selected " + tag);
    }


    enum GameState
    {
        WorldMap,
        ContinentMap
    }

}
