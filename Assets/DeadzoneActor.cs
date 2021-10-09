using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadzoneActor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag($"AI"))
        {
            Destroy(other.gameObject);
            GameplayManager.Instance.KillPlayer();
        }
    }
}
