using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class FoodManager : MonoBehaviour
{
    public int startingFoodCount;
    public int maxFoodCount;

    public GameObject platform;

    
    public float spawnInterval;

    private int _currentFoodCount = 0;

    private Collider _platformCollider;
    // Start is called before the first frame update
    void Start()
    {
        _platformCollider = platform.GetComponent<Collider>();
        Debug.Log($"Platform Collider bounds {_platformCollider.bounds}");
        
        // Responsibility 1: FoodSpawn
        SetStartingFoods();
        SpawnFoodWithInterval();
    }

    private void SpawnFoodWithInterval()
    {
        // _platformCollider.bounds.center
    }

    private void SetStartingFoods()
    {
        for (int i = 0; i < startingFoodCount; i++)
        {
            var obj = ObjectPool._pool.Dequeue();

            var spawnLocation = FindSpawnLocation();
            obj.transform.position = spawnLocation;
            obj.SetActive(true);
            IncrementFood();
        }
    }

    private Vector3 FindSpawnLocation()
    {
        var center = _platformCollider.bounds.center;
        var extents = _platformCollider.bounds.extents;
        Vector3 loc = new Vector3(Random.Range(center.x, center.x + extents.x),
            platform.transform.position.y + 0.5f,
            Random.Range(center.z, center.z + extents.z));
            
            NavMeshHit hit;
            Vector3 finalPosition = Vector3.zero;
            if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) {
                finalPosition = hit.position;            
            }
            return finalPosition;
    }

    public void DecrementFood()
    {
        
    }

    public void IncrementFood()
    {
        _currentFoodCount++;
    }

    // private void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.red;
    //     if(_platformCollider != null)
    //         Gizmos.DrawSphere(_platformCollider.bounds.center,10f);
    // }
}
