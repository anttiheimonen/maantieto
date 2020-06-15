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
        gamestate = GameState.QuizStarting;
        if (gamestate == GameState.QuizStarting)
        {
            Debug.Log("jee");
        }
    }


    public void SelectCountry(string tag)
    {
        Debug.Log("Country selected " + tag);
        if (gamestate == GameState.QuizRunning)
            GuessCountry(tag);
    }


    private bool GuessCountry(string tag)
    {

        return true;
    }


    private void StartQuiz()
    {
        CountryData lookingFor = cm.GetRandomCountryData();
        Debug.Log("Looking for " + lookingFor.GetTag());
        var hintStack = new Stack<string>(lookingFor.GetHints());
        Debug.Log(hintStack.Pop());
        // TODO: Kesken
    }


    /// Puts country hints into a stack in randomized order.
    private Stack<string> GetSuffledHints(CountryData country)
    {
        var list = new List<string>(country.GetHints());
        int n = list.Count;
        System.Random rnd = new System.Random();
        while (n > 1)
        {
            n--;
            int k = rnd.Next(n + 1);
            var value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        var hintStack = new Stack<string>();

        foreach (var hint in list)
        {
            hintStack.Push(hint);
        }
        return hintStack;
    }


    enum GameState
    {
        WorldMap,
        QuizStarting,
        QuizRunning,
        QuizEnd

    }

}
