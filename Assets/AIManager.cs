using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    private List<Transform> elementsOnPlatform = new List<Transform>();

    private void Awake()
    {
        var player = GameObject.FindGameObjectsWithTag("Player");
        var ais = GameObject.FindGameObjectsWithTag("AI");

        foreach (var i in player)
        {
            elementsOnPlatform.Add(i.transform);
        }
        foreach (var i in ais)
        {
            elementsOnPlatform.Add(i.transform);
        }
    }
}
