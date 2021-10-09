using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class AIActor : MonoBehaviour
{
    private List<Transform> elementsOnPlatform = new List<Transform>();
    private PlayerActor _playerActor;

    private void Awake()
    {
        _playerActor = GetComponent<PlayerActor>();

        
        
    }

    private void Update()
    {
        if (_playerActor.isActive)
        {
            
        }
    }

    // private void FindClosestObject()
    // {
    //     Transform currentClosest;
    //     foreach (var i in elementsOnPlatform)
    //     {
    //         if (i.GetComponent<PlayerActor>().isActive && i != transform)
    //         {
    //             Vector3.Distance(i.position,transform.position)
    //             if(i.position)
    //         }
    //     }
    // }
}
