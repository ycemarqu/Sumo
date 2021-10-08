using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject humanPrefab;

    public int poolSize;

    [NonSerialized] public static Queue<GameObject> _pool = new Queue<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            var obj = Instantiate(humanPrefab);
            obj.SetActive(false);
            _pool.Enqueue(obj);
            
        }
    }
}
