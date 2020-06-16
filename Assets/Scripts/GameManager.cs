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

    private int hintNumber = 0;


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
    }


    public void SelectContinent(string tag)
    {
        Debug.Log("Selected continent: " + tag);
        selectedContinent = tag;
        cm.LoadContinentData(tag);
        ui.InitializeScore(0, 100);
        gamestate = GameState.QuizRunning;
        InitializeQuestion();
    }


    public void SelectCountry(string tag)
    {
        Debug.Log("Country selected " + tag);
        if (gamestate == GameState.QuizRunning)
        {
            bool answer = GuessCountry(tag);
            GameObject c = GameObject.Find(tag);
            c.GetComponent<CountryController>().AnswerIs(answer);
        }
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
        ui.RightAnswer(lookingFor.GetName());
        gamestate = GameState.QuizEnd;
    }


    private void WrongAnswer()
    {
        Debug.Log("Wrong answer");
        GiveHint();
    }


    /// Clear the color coding on contries
    private void ClearContriesMarking()
    {
        GameObject[] conts = GameObject.FindGameObjectsWithTag("Continent");
        foreach (var c in conts)
        {
            var childs = c.GetComponentsInChildren(typeof(Transform));
            foreach (var country in childs)
            {
                if (country.tag != "Continent")
                {
                    country.GetComponent<CountryController>().ClearColorCoding();
                }
            }
        }
    }


    private void GiveHint()
    {
        hintNumber++;
        string hint = "";
        try
        {
            hint = "-- " + hintNumber + ". Vihje --\n" + hintStack.Pop();
        }
        catch (InvalidOperationException e)
        {
            e.ToString();
            Debug.Log("Vinkit loppu :(");
        }
        ui.UpdateQuestion(hint);
    }


    private void GivePoints(int pts)
    {
        points = points + pts;
        ui.SetScore(points);
    }


    public void NewQuestion()
    {
        InitializeQuestion();
    }


    private void InitializeQuestion()
    {
        hintNumber = 0;
        UIManager.instance.ClearQuestionBox();
        UIManager.instance.ClearAnswerFeedBack();
        ClearContriesMarking();
        lookingFor = cm.GetRandomCountryData();
        gamestate = GameState.QuizRunning;
        Debug.Log("Looking for " + lookingFor.GetTag());
        hintStack = GetSuffledHints(lookingFor);
        GiveHint();
    }


    /// Puts country hints into a stack in randomized order.
    private Stack<string> GetSuffledHints(CountryData country)
    {
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
