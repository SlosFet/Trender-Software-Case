using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Using mvc pattern here. This script controls all enemy scripts

    [SerializeField] private EnemyAI _enemyAI;
    [SerializeField] private EnemyAttack _enemyAttack;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private EnemyDrop _enemyDrop;
    [SerializeField] private EnemyAnimController _enemyAnimController;

    [SerializeField] private GameObject _mesh;

    public bool canSpawnable;
    [SerializeField] private float _spawnAgainTime;
    private bool isGameEnded = false;

    private void OnEnable()
    {
        GameManager.OnGameOver += OnGameEnd;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= OnGameEnd;
    }

    private void Start()
    {
        _enemyHealth.OnDeath += OnDeath;
        _enemyHealth.OnGetDamage += _enemyAnimController.HitAnim;
    }

    private void Update()
    {
        if (_enemyHealth.isDeath || isGameEnded)
            return;

        _enemyAI.HandleDirection();

        if (_enemyAI.shouldFollow || _enemyAI.isFearActivated)
            _enemyAI.Move();
        else
        {
            _enemyAttack.Attack();
        }
    }

    private void OnDeath()
    {
        _enemyDrop.GetDrop();
        _mesh.SetActive(false);
        Invoke(nameof(SetSpawnableInvoker), _spawnAgainTime);
    }

    public void Spawn(Vector3 pos)
    {
        transform.position = pos;
        _mesh.SetActive(true);
        canSpawnable = false;
        _enemyHealth.OnSpawn();
    }    

    private void SetSpawnableInvoker()
    {
        canSpawnable = true;
    }

    private void OnGameEnd()
    {
        isGameEnded = true;
    }
}
