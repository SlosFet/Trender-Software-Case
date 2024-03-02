using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyAI _enemyAI;
    [SerializeField] private EnemyAttack _enemyAttack;
    [SerializeField] private EnemyHealth _enemyHealth;

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
}
