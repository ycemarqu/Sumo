using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class FoodManager : MonoBehaviour
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
    
    [Header("Food Counts")]
    [Tooltip("Food count that is initialized at beginning of level")]public int startingFoodCount;
    [Tooltip("Maximum Count of Foods that can exist on scene")]public int maxFoodCount;

    [Header("Platform")]
    public GameObject platform;

    [NonSerialized]public Collider _platformCollider;
    [NonSerialized]public int _currentFoodCount = 0;

    [Header("Dependencies")]
    public GameObject dependencies;
    
    private ISpawnFood _spawnFood;
    

    private void Awake()
    {
        instance = this;
        _spawnFood = dependencies.GetComponent<ISpawnFood>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _platformCollider = platform.GetComponent<Collider>();
        _spawnFood.SetStartingFoods(startingFoodCount);
        _spawnFood.RepeatingSpawnFood();
    }


    public void DecrementFood()
    {
        _currentFoodCount--;
    }

    public void IncrementFood()
    {
        _currentFoodCount++;
    }
}