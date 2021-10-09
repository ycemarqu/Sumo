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

    public static event Action<GameStates> ChangeState;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(ChangeGameState(GameStates.Starting,0f));
        
        StartCoroutine(ChangeGameState(GameStates.Playing, 3f));
    }

    private IEnumerator ChangeGameState(GameStates state, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _currentState = state;
        ChangeState?.Invoke(state);
    }
}
