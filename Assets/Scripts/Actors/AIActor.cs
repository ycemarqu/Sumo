using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;


public class AIActor : MonoBehaviour
{
    private PlayerActor _playerActor;
    private NavMeshAgent _agent;
    private Vector3 _target;

    private void Awake()
    {
        _playerActor = GetComponent<PlayerActor>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        AIManager.Instance.InitializeElements();
        InvokeRepeating(nameof(SetDestination), 0f, 2f);
    }

    private void SetDestination()
    {
        if (_playerActor.isActive)
        {
            _target = GetClosestEnemy(AIManager.Instance.elements).position;
            // Debug.Log("Repeat");
        }
    }

    private void Update()
    {
        if (GameplayManager.Instance._currentState == GameStates.Playing)
        {
            _agent.destination = _target;
        }
    }

    public Transform GetClosestEnemy(List<Transform> enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in enemies)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist && t.gameObject != gameObject)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }

}
