using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIStates
{
    Starting,
    Playing,
    End
    
}

public class UIManager : MonoBehaviour
{
    #region Singleton

    private static UIManager instance = null;
    
    
    // Game Instance Singleton
    public static UIManager Instance
    {
        get
        { 
            return instance; 
        }
    }

    #endregion

    private GameStates _currentState;
    private GameObject UItoActivate;

    public SerializableDictionary<GameStates, GameObject> _StateCorrespondingUI;

    private void Awake()
    {
        instance = this;
    }
    
    private void OnEnable()
    {
        GameplayManager.ChangeState += GameplayManagerOnChangeState;
    }

    private void OnDisable()
    {
        GameplayManager.ChangeState -= GameplayManagerOnChangeState;
    }

    private void GameplayManagerOnChangeState(GameStates state)
    {
        // Disable Previous UI
        if(UItoActivate != null)
            UItoActivate.SetActive(false);
        // Activate new UI
        UItoActivate = _StateCorrespondingUI[state];
        UItoActivate.SetActive(true);
    }
}
