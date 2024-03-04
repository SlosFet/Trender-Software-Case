using System;
using UnityEngine;

public class InGameDatas : MonoBehaviour
{
    private int killCount;
    private float playTime = 0;
    private float startMoney;
    public static event Action<int> SendKillCount;
    public static event Action<float> SendPlayTime;
    public static event Action<float> SendCollectedMoney;

    private bool isGameStarted = false;
    private bool isGameEnded = false;
    private void OnEnable()
    {
        EnemyHealth.increaseDeathCount += IncreaseDeathCount;
        GameManager.OnGameOver += OnGameEnd;
        GameManager.OnGameStarted += OnGameStart;
    }

    private void OnDisable()
    {
        EnemyHealth.increaseDeathCount -= IncreaseDeathCount;
        GameManager.OnGameOver -= OnGameEnd;
        GameManager.OnGameStarted -= OnGameStart;
    }

    private void Start()
    {
        startMoney = MoneyManager.Instance.money;
    }

    private void IncreaseDeathCount()
    {
        killCount++;
    }

    private void OnGameEnd()
    {
        isGameEnded = true;
        SendKillCount?.Invoke(killCount);
        SendPlayTime?.Invoke(playTime);
        SendCollectedMoney?.Invoke(MoneyManager.Instance.money - startMoney);
    }

    private void OnGameStart()
    {
        isGameStarted = true;
    }

    private void Update()
    {
        if (!isGameStarted || isGameEnded)
            return;

        playTime += Time.deltaTime;
        SendPlayTime?.Invoke(playTime);
    }
}
