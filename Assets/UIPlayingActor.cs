using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPlayingActor : MonoBehaviour
{
    private GameplayManager _gameplayInstance;
    
    
    public GameObject remainingPlayerCountObject, scoreObject, remainingSecondsObject;
    private TextMeshProUGUI remainingPlayerCountTMP, scoreTMP, remainingSecondsTMP;

    private void Awake()
    {
        _gameplayInstance = GameplayManager.Instance;
        remainingPlayerCountTMP = remainingPlayerCountObject.GetComponent<TextMeshProUGUI>();
        scoreTMP = scoreObject.GetComponent<TextMeshProUGUI>();
        remainingSecondsTMP = remainingSecondsObject.GetComponent<TextMeshProUGUI>();

        remainingPlayerCountTMP.text = _gameplayInstance.PlayerCountOnPlatform.ToString();
        remainingSecondsTMP.text = _gameplayInstance.levelDuration.ToString();
    }

    private void OnEnable()
    {
        
        GameplayManager.PlayerCountChanged += () => remainingPlayerCountTMP.text = GameplayManager.Instance.PlayerCountOnPlatform.ToString();;
        GameplayManager.RemainingSecondChanged += () => remainingSecondsTMP.text = GameplayManager.Instance.levelDuration.ToString();
        // GameplayManager.ScoreChanged += () => remainingSecondsTMP.text = GameplayManager.Instance..ToString();
    }

    private void OnDisable()
    {
        GameplayManager.PlayerCountChanged -= () => remainingPlayerCountTMP.text = GameplayManager.Instance.PlayerCountOnPlatform.ToString();;
        GameplayManager.RemainingSecondChanged -= () => remainingSecondsTMP.text = GameplayManager.Instance.levelDuration.ToString();
    }

    
}
