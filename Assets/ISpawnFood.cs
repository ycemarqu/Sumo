using UnityEngine;

public interface ISpawnFood
{
    void SetStartingFoods(int startingFoodCount);
    void RepeatingSpawnFood();
    void SpawnOneFood();
    Vector3 FindSpawnLocation();
}