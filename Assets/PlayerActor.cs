using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerActor : MonoBehaviour
{
    public bool isActive = true;
    public int score = 1000;
    private Rigidbody _rb;
    private float _scalingFactor;
    private float _pushPower;

    private Transform lastPusher;
    [NonSerialized] public int killedPlayerCount = 0;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _scalingFactor = GameplayManager.Instance.scalingFactor;
        _pushPower = GameplayManager.Instance.pushPower;
    }

    public void IncreaseScore(int score = 100)
    {
        this.score += score;
        GameplayManager.Instance.FireScoreChangeEvent();
        IncreaseSize(score / 100f);
    }

    public void PickedUpBoost()
    {
        IncreaseScore();
    }

    private void IncreaseSize(float times)
    {
        transform.localScale += new Vector3(_scalingFactor, _scalingFactor, _scalingFactor) * times;
        _rb.drag += 0.03f*times;
    }

    public void TransferScores()
    {
        if (lastPusher != null)
        {
            var actor = lastPusher.GetComponent<PlayerActor>();
            actor.IncreaseScore(score);
            actor.killedPlayerCount++;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        
        var collider = other.collider;
        if (collider.CompareTag("Player") || collider.CompareTag($"AI"))
        {
            lastPusher = collider.transform;
            var enemyRB = collider.attachedRigidbody;

            var temp = collider.transform.position - transform.position;
            temp.y = 0;
            enemyRB.AddForce(temp * _pushPower * (score/2000f), ForceMode.Impulse);
        }
    }
}
