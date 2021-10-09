using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIEndActor : MonoBehaviour
{
    public GameObject player;
    public GameObject defeatedSumoCountObject, rankObject;
    private TextMeshProUGUI defeatedSumoCountTMP, rankTMP;
    private PlayerActor _playerActor;

    private void Awake()
    {
        defeatedSumoCountTMP = defeatedSumoCountObject.GetComponent<TextMeshProUGUI>();
        rankTMP = rankObject.GetComponent<TextMeshProUGUI>();

        _playerActor = player.GetComponent<PlayerActor>();
    }

    private void OnEnable()
    {
        
        GameplayManager.GameoverEvent += () => defeatedSumoCountTMP.text = $"Sumos Defeated:{_playerActor.killedPlayerCount}";
    }

    private void OnDisable()
    {
        GameplayManager.GameoverEvent += () => defeatedSumoCountTMP.text = $"Sumos Defeated:{_playerActor.killedPlayerCount}";
    }
}
