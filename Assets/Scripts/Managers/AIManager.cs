using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;


public class AIManager : Singleton<AIManager>
{
    public List<Transform> elements;
    
    private void Start()
    {
        InvokeRepeating(nameof(InitializeElements), 0f, 1f);
    }

    public void InitializeElements()
    {
        elements = new List<Transform>();
        var Player = GameObject.FindGameObjectsWithTag("Player");
        var Ais = GameObject.FindGameObjectsWithTag("AI");
        var Foods = GameObject.FindGameObjectsWithTag("Food");

        AppendToList(Player);
        AppendToList(Ais);
        AppendToList(Foods);
    }

    private void AppendToList(GameObject[] arr)
    {
        foreach (var i in arr)
        {
            elements.Add(i.transform);
        }
    }
}
