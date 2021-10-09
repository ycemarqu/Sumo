using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerActor : MonoBehaviour
{
    private int _score = 1000, collectedFoodCount = 0, killedPlayerCount = 0;
    private Rigidbody _rb;
    private float _scalingFactor;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _scalingFactor = GameplayManager.Instance.scalingFactor;
    }

    public void IncreaseScore(int score = 100)
    {
        _score += score;
        collectedFoodCount++;
    }

    public void PickedUpBoost()
    {
        IncreaseScore();
        IncreaseSize();
    }

    private void IncreaseSize()
    {
        
        transform.localScale += new Vector3(_scalingFactor, _scalingFactor, _scalingFactor);
    }
}
