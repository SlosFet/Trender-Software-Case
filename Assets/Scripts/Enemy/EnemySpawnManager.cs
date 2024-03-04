using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;

    [SerializeField] private List<Transform> _enemySpawnPoints;

    [SerializeField] private float _enemySpawnTime;
    [SerializeField] private float _minEnemySpawnTime;
    [SerializeField] private float _enemySpawnTimeIncreaseAmount;

    [SerializeField] private int _startEnemyCount;

    private int index;
    private bool isGameEnded = false;
    private bool isGameStarted = false;

    private void OnEnable()
    {
        GameManager.OnGameOver += OnGameEnd;
        GameManager.OnGameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= OnGameEnd;
        GameManager.OnGameStarted -= OnGameStarted;
    }

    private void SpawnEnemy(Enemy enemy,Transform spawnPoint = null)
    {
        if (isGameEnded || !isGameStarted)
            return;
        if(!_enemies[index].canSpawnable)
        {
            IncreaseIndex();
            SpawnEnemy(enemy, spawnPoint);
            return;
        }

        enemy.gameObject.SetActive(true);
        
        if (spawnPoint == null)
            spawnPoint = _enemySpawnPoints[Random.Range(0, _enemySpawnPoints.Count)];
        enemy.Spawn(spawnPoint.position);
        IncreaseIndex();
    }

    private IEnumerator EnemySpawner()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(_enemySpawnTime);
            _enemySpawnTime -= _enemySpawnTimeIncreaseAmount;
            _enemySpawnTime = Mathf.Clamp(_enemySpawnTime, _minEnemySpawnTime, Mathf.Infinity);
            SpawnEnemy(_enemies[index]);
        }
    }

    private void IncreaseIndex()
    {
        index++;
        if (index >= _enemies.Count)
            index = 0;
    }

    private void OnGameEnd()
    {
        isGameEnded = true;
    }

    private void OnGameStarted()
    {
        isGameStarted = true;
        for (int i = 0; i < _startEnemyCount; i++)
        {
            SpawnEnemy(_enemies[index], _enemySpawnPoints[i]);
        }

        StartCoroutine(EnemySpawner());
    }
}
