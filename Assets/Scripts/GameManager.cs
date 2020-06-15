using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private ContinentManager cm;

    private string selectedContinent;

    private GameState gamestate;

    private CountryData lookingFor;

    private int points = 0;

    private UIManager ui;

    private Stack<string> hintStack;


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
        ui = FindObjectOfType<UIManager>();
        Debug.Log(cm.Debugaa());

        // Debugging stuff
        // SelectContinent("africa");
        // StartQuiz();
    }


    public void SelectContinent(string tag)
    {
        Debug.Log("Selected continent: " + tag);
        selectedContinent = tag;
        cm.LoadContinentData(tag);
        gamestate = GameState.QuizRunning;
        StartQuiz();
    }


    public void SelectCountry(string tag)
    {
        Debug.Log("Country selected " + tag);
        if (gamestate == GameState.QuizRunning)
            GuessCountry(tag);
    }


    private bool GuessCountry(string tag)
    {
        Debug.Log(lookingFor.GetTag());
        if (tag == lookingFor.GetTag())
        {
            RightAnswer();
            return true;
        }

        WrongAnswer();
        return false;
    }


    private void RightAnswer()
    {
        GivePoints(5);
        Debug.Log("GAMEMANAGER OIKEIN");
        ui.RightAnswer(lookingFor.GetName());
    }


    private void WrongAnswer()
    {
        Debug.Log("Wrong answer");
        GiveHint();
    }


    private void GiveHint()
    {
        string hint = "";
        try
        {
            hint = hintStack.Pop();
        }
        catch (InvalidOperationException e)
        {
            Debug.Log("Vinkit loppu :(");
        }
        ui.UpdateQuestion(hint);
    }


    private void GivePoints(int pts)
    {
        points = points + pts;
    }


    private void StartQuiz()
    {
        lookingFor = cm.GetRandomCountryData();
        Debug.Log("Looking for " + lookingFor.GetTag());
        hintStack = GetSuffledHints(lookingFor);
        GiveHint();
    }


    /// Puts country hints into a stack in randomized order.
    private Stack<string> GetSuffledHints(CountryData country)
    {
        // var list = new List<string>(country.GetHints());
        // int n = list.Count;

        var list = country.GetHints();
        int n = country.GetHints().Length;
        System.Random rnd = new System.Random();
        while (n > 0)
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
