using UnityEngine;
using UnityEngine.AI;

public class SpawnFood: MonoBehaviour, ISpawnFood
{
    public float spawnInterval;
    public void SetStartingFoods(int startingFoodCount)
    {
        for (int i = 0; i < startingFoodCount; i++)
        {
            SpawnOneFood();
        }
    }

    public void RepeatingSpawnFood()
    {
        InvokeRepeating(nameof(IntervalSpawner), 2.0f, spawnInterval);
    }
    
    void IntervalSpawner()
    {
        if (FoodManager.Instance._currentFoodCount < FoodManager.Instance.maxFoodCount) SpawnOneFood();
    }
    public void SpawnOneFood()
    {
        //TODO enqueue when it's picked up by players so queue is never empty
        var obj = ObjectPool._pool.Dequeue();
        var spawnLocation = FindSpawnLocation();
        obj.transform.position = spawnLocation;
        obj.SetActive(true);
        FoodManager.Instance.IncrementFood();
    }

    public Vector3 FindSpawnLocation()
    {
        var bounds = FoodManager.Instance._platformCollider.bounds;
        var center = bounds.center;
        var extents = bounds.extents;
        
        Vector3 loc = new Vector3(Random.Range(center.x - extents.x, center.x + extents.x), center.y + 0.5f,
            Random.Range(center.z - extents.z, center.z + extents.z));
            
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(loc, out hit, 3f, 1)) {
            finalPosition = hit.position;            
        }
        return finalPosition;
    }
}