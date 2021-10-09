using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public struct ElementsOnPlatform
{
    public GameObject[] Player;
    public GameObject[] Ais;
    public GameObject[] Foods;
    
    public void InitializePlayerAndAI()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        Ais = GameObject.FindGameObjectsWithTag("AI");
    }

    public void InitializeFoods()
    {
        Foods = GameObject.FindGameObjectsWithTag("Food");
    }
}

public class AIManager : MonoBehaviour
{
    #region Singleton

    private static AIManager instance = null;
    
    
    // Game Instance Singleton
    public static AIManager Instance
    {
        get
        { 
            return instance; 
        }
    }

    #endregion

    public ElementsOnPlatform Elements;
    
    private void Awake()
    {
        instance = this;
        Elements.InitializePlayerAndAI();
    }

    
}
