using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    INTRO, CASEDIALOGUE, OUTCOME
}

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    private int currentCase = 1;

    public GameState state = GameState.INTRO;

    private bool hasGameStarted = false;

    private void Awake()
    {
        if (_instance)
        {
            Destroy(gameObject);
        } else
        {
            _instance = this;

            DontDestroyOnLoad(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        hasGameStarted = true;
        
    }

    private void StartCase(int currentCase, GameState state)
    {
        
    }

    public void GoToNextState()
    {
        switch (state)
        {
            case GameState.INTRO:
                state = GameState.CASEDIALOGUE;
                break;
            case GameState.CASEDIALOGUE:
                state = GameState.OUTCOME;
                break;
            case GameState.OUTCOME:
                state = GameState.INTRO;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(hasGameStarted)
        {
            StartCase(currentCase, state);
        }
    }


}
