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


    void Start()
    {
        cm = new ContinentManager(); // gameObject.AddComponent(typeof(ContinentManager)) as ContinentManager;
        Debug.Log(cm.Debugaa());
    }


    public void SelectContinent(string tag)
    {
        Debug.Log("Selected continent: " + tag);
        selectedContinent = tag;
        cm.LoadContinentData(tag);
        gamestate = GameState.AfricaMap;
        if (gamestate == GameState.AfricaMap)
        {
            Debug.Log("jee");
        }
    }


    public void SelectCountry(string tag)
    {
        Debug.Log("Country selected " + tag);
    }


    private void StartQuiz()
    {
        CountryData lookingFor = cm.GetRandomCountryData();
        // TODO: Kesken
    }


    enum GameState
    {
        WorldMap,
        AfricaMap
    }

}
