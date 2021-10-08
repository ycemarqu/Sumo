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
    private GameStates _currentState;
    
    public static event Action<GameStates> ChangeState;

    private void Start()
    {
        ChangeGameState(GameStates.Starting);
    }

    private void ChangeGameState(GameStates state)
    {
        _currentState = state;
        ChangeState?.Invoke(state);
    }
}
