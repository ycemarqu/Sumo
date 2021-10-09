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

    private void Awake()
    {
        _playerActor = GetComponent<PlayerActor>();
        _agent = new NavMeshAgent();
    }

    private void Start()
    {
        // _agent.SetDestination(FindClosestObject().position);
    }

    private void Update()
    {
        if (_playerActor.isActive)
        {
            
        }
    }

    // private Transform FindClosestObject()
    // {
    //     Dictionary<Transform,float> currentClosest = new Dictionary<Transform, float>();
    //     foreach (var i in AIManager.Instance.Elements)
    //     {
    //         if (i.GetComponent<PlayerActor>().isActive && i != transform)
    //         {
    //             var dist = Vector3.Distance(i.position, transform.position);
    //             if(dist < currentClosest.Values.Single())
    //                 currentClosest = {i,dist};
    //         }
    //     }
    //
    //     return currentClosest.Keys.Single();
    // }
}
