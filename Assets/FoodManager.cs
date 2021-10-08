using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class FoodManager : MonoBehaviour
{
    [Header("Food Counts")]
    [Tooltip("Food count that is initialized at beginning of level")]public int startingFoodCount;
    [Tooltip("Maximum Count of Foods that can exist on scene")]public int maxFoodCount;

    [Header("Platform")]
    public GameObject platform;

    
    public float spawnInterval;

    private int _currentFoodCount = 0;

    private Collider _platformCollider;
    // Start is called before the first frame update
    void Start()
    {
        _platformCollider = platform.GetComponent<Collider>();
        
        // Responsibility 1: FoodSpawn
        SetStartingFoods();
        InvokeRepeating("RepeatingSpawnFood", 2.0f, spawnInterval);
    }
    

    public void SetStartingFoods()
    {
        for (int i = 0; i < startingFoodCount; i++)
        {
            SpawnFood();
        }
    }

    public void RepeatingSpawnFood()
    {
        if (_currentFoodCount < maxFoodCount)
            SpawnFood();
    }

    public void SpawnFood()
    {
        //TODO enqueue when it's picked up by players so queue is never empty
        var obj = ObjectPool._pool.Dequeue();
        var spawnLocation = FindSpawnLocation();
        obj.transform.position = spawnLocation;
        obj.SetActive(true);
        IncrementFood();
    }

    public Vector3 FindSpawnLocation()
    {
        var center = _platformCollider.bounds.center;
        var extents = _platformCollider.bounds.extents;
        Vector3 loc = new Vector3(Random.Range(center.x - extents.x, center.x + extents.x),
            platform.transform.position.y + 0.5f,
            Random.Range(center.z - extents.z, center.z + extents.z));
            
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(loc, out hit, 3f, 1)) {
            finalPosition = hit.position;            
        }
        return finalPosition;
        // return loc;
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
