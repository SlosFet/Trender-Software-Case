using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static event Action OnGameOver;
    public static event Action OnGameStarted;
    public static event Action<float> OnGameStarting;
    public CurrentOS currentOS;
    [SerializeField] private float gameStartTime;
    private void Awake()
    {
        Instance = this;
    }

    private IEnumerator Start()
    {
        Application.targetFrameRate = 60;
        OnGameStarting?.Invoke(gameStartTime);
        yield return new WaitForSecondsRealtime(gameStartTime);
        StartGame();
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
    }

    public void StartGame()
    {
        OnGameStarted?.Invoke();
    }

}

[System.Serializable]
public enum CurrentOS
{
    Windows,
    Android
}
