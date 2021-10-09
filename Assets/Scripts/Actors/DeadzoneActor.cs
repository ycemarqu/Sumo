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
            GameplayManager.Instance.KillPlayer(other.GetComponent<PlayerActor>());
            other.GetComponent<PlayerActor>().isActive = false;

            if (other.CompareTag("Player"))
            {
                GameplayManager.Instance.Gameover();
            }
        }
    }
}
