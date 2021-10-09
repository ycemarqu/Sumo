using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameStates
{
    Starting,
    Playing,
    End
    
}
[DefaultExecutionOrder(-1)]
public class GameplayManager : MonoBehaviour
{
    #region Singleton

    private static GameplayManager instance = null;
    
    
    // Game Instance Singleton
    public static GameplayManager Instance
    {
        get
        { 
            return instance; 
        }
    }

    #endregion
    
    public GameStates _currentState;
    public int levelDuration;

    [Header("Player Attributes")]
    public float scalingFactor;
    public float playerSpeed;
    public float pushPower;
    
    public GameObject players;

    public int PlayerCountOnPlatform { get; private set; } = 0;

    public static event Action<GameStates> ChangeState;
    public static event Action PlayerCountChanged, RemainingSecondChanged, GameoverEvent, ScoreChanged;

    private void Awake()
    {
        instance = this;
        SetPlayerCount(players.transform.childCount);
    }

    private void Start()
    {
        StartCoroutine(ChangeGameState(GameStates.Starting,0f));
        StartCoroutine(ChangeGameState(GameStates.Playing, 3f));
        
        InvokeRepeating(nameof(Countdown),0f,1f);

    }

    private void Countdown()
    {
        if (levelDuration <= 0)
        {
            Gameover();
        }
        
        if (_currentState != GameStates.Playing) return;
        levelDuration -= 1;
        RemainingSecondChanged?.Invoke();
    }

    private IEnumerator ChangeGameState(GameStates state, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _currentState = state;
        ChangeState?.Invoke(state);
    }

    public void KillPlayer(PlayerActor killedActor)
    {
        killedActor.TransferScores();
        PlayerCountOnPlatform--;
        PlayerCountChanged?.Invoke();
        
        if (PlayerCountOnPlatform == 1)
        {
            Gameover();
        }
    }

    public void Gameover()
    {
        StartCoroutine(ChangeGameState(GameStates.End, 0f));
        GameoverEvent?.Invoke();
    }

    public void SetPlayerCount(int count)
    {
        PlayerCountOnPlatform = count;
        PlayerCountChanged?.Invoke();
    }

    public void FireScoreChangeEvent()
    {
        ScoreChanged?.Invoke();
    }
}
