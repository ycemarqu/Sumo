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
    private float _pushPower;

    private Transform lastPusher;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _scalingFactor = GameplayManager.Instance.scalingFactor;
        _pushPower = GameplayManager.Instance.pushPower;
    }

    public void IncreaseScore(int score = 100)
    {
        _score += score;
        collectedFoodCount++;
        IncreaseSize(score / 100f);
    }

    public void PickedUpBoost()
    {
        IncreaseScore();
    }

    private void IncreaseSize(float times)
    {
        transform.localScale += new Vector3(_scalingFactor, _scalingFactor, _scalingFactor) * times;
    }

    public void TransferScores()
    {
        if(lastPusher != null) lastPusher.GetComponent<PlayerActor>().IncreaseScore(_score);
    }

    private void OnCollisionEnter(Collision other)
    {
        
        var collider = other.collider;
        if (collider.CompareTag("Player") || collider.CompareTag($"AI"))
        {
            lastPusher = collider.transform;
            var enemyRB = collider.attachedRigidbody;
            enemyRB.AddForce((collider.transform.position - transform.position) * _pushPower * (_score/1000f), ForceMode.Impulse);
        }
    }
}
