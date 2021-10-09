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
    public float playerSpeed;
    public int levelDuration;

    public GameObject players;

    public int PlayerCountOnPlatform { get; private set; } = 0;

    public static event Action<GameStates> ChangeState;
    public static event Action PlayerCountChanged, RemainingSecondChanged;

    private void Awake()
    {
        instance = this;
        SetPlayerCount(players.transform.childCount);
    }

    private void Start()
    {
        StartCoroutine(ChangeGameState(GameStates.Starting,0f));
        StartCoroutine(ChangeGameState(GameStates.Playing, 3f));
        
        if(levelDuration > 0 )
            InvokeRepeating(nameof(Countdown),0f,1f);
    }

    private void Countdown()
    {
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

    public void KillPlayer()
    {
        PlayerCountOnPlatform--;
        PlayerCountChanged?.Invoke();
    }

    public void SetPlayerCount(int count)
    {
        PlayerCountOnPlatform = count;
        PlayerCountChanged?.Invoke();
    }
}
