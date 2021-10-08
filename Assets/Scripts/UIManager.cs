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

    private static FoodManager instance = null;
    
    // Game Instance Singleton
    public static FoodManager Instance
    {
        get
        { 
            return instance; 
        }
    }

    #endregion

    public SerializableDictionary<UIStates, GameObject> _UIStates;
    
    
}
