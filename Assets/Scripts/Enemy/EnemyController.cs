using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyAI _enemyAI;
    [SerializeField] private EnemyAttack _enemyAttack;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private EnemyDrop _enemyDrop;

    [SerializeField] private GameObject _mesh;

    private void Start()
    {
        _enemyHealth.OnDeath += OnDeath;
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
    }

    public void Spawn(Vector3 pos)
    {
        transform.position = pos;
        _mesh.SetActive(true);
    }    
}