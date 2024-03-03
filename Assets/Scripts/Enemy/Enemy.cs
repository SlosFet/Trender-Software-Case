using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyAI _enemyAI;
    [SerializeField] private EnemyAttack _enemyAttack;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private EnemyDrop _enemyDrop;
    [SerializeField] private EnemyAnimController _enemyAnimController;

    [SerializeField] private GameObject _mesh;

    public bool canSpawnable;
    [SerializeField] private float _spawnAgainTime;

    private void Start()
    {
        _enemyHealth.OnDeath += OnDeath;
        _enemyHealth.OnGetDamage += _enemyAnimController.HitAnim;
    }

    private void Update()
    {
        if (_enemyHealth.isDeath)
            return;

        _enemyAI.HandleDirection();

        if (_enemyAI.shouldFollow)
            _enemyAI.Move();
        else
        {
            _enemyAttack.Attack();
            print("Attacked1");
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
}
