using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPlayingActor : MonoBehaviour
{
    public GameObject player;
    private GameplayManager _gameplayInstance;
    private PlayerActor _playerActor;
    
    
    public GameObject remainingPlayerCountObject, scoreObject, remainingSecondsObject;
    private TextMeshProUGUI remainingPlayerCountTMP, scoreTMP, remainingSecondsTMP;

    private void Awake()
    {
        _gameplayInstance = GameplayManager.Instance;
        _playerActor = player.GetComponent<PlayerActor>();
        
        remainingPlayerCountTMP = remainingPlayerCountObject.GetComponent<TextMeshProUGUI>();
        scoreTMP = scoreObject.GetComponent<TextMeshProUGUI>();
        remainingSecondsTMP = remainingSecondsObject.GetComponent<TextMeshProUGUI>();

        remainingPlayerCountTMP.text = _gameplayInstance.PlayerCountOnPlatform.ToString();
        remainingSecondsTMP.text = _gameplayInstance.levelDuration.ToString();
        scoreTMP.text = _playerActor.score.ToString();
    }

    private void OnEnable()
    {
        
        GameplayManager.PlayerCountChanged += () => remainingPlayerCountTMP.text = GameplayManager.Instance.PlayerCountOnPlatform.ToString();;
        GameplayManager.RemainingSecondChanged += () => remainingSecondsTMP.text = GameplayManager.Instance.levelDuration.ToString();
        GameplayManager.ScoreChanged += () => scoreTMP.text = _playerActor.score.ToString();
    }

    private void OnDisable()
    {
        GameplayManager.PlayerCountChanged -= () => remainingPlayerCountTMP.text = GameplayManager.Instance.PlayerCountOnPlatform.ToString();;
        GameplayManager.RemainingSecondChanged -= () => remainingSecondsTMP.text = GameplayManager.Instance.levelDuration.ToString();
        GameplayManager.ScoreChanged -= () => scoreTMP.text = _playerActor.score.ToString();
    }

    
}
