using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodActor : MonoBehaviour
{
    private bool isActive = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag($"AI"))
        {
            other.GetComponent<PlayerActor>().PickedUpBoost();
            
            FoodManager.Instance.DeleteFood(gameObject);
        }
    }
}
