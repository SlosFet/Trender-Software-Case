using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    public bool isAttacking { get { return _weapon.isAttacking; } }
    public void Attack()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 direction = (player.position - transform.position).normalized;

        _weapon.Attack(direction);
    }
}
