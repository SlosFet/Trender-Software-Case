using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    private bool isGameEnded = false;
    private Vector3 currentDirection;
    private void OnEnable()
    {
        InputManager.OnAttack.AddListener(Attack);
        GameManager.OnGameOver += OnGameEnd;
    }

    private void OnDisable()
    {
        InputManager.OnAttack.RemoveListener(Attack);
        GameManager.OnGameOver -= OnGameEnd;
    }

    private void Attack(Vector3 direction)
    {
        if (isGameEnded)
            return;

        currentDirection = direction;
        direction = (direction - transform.position).normalized;
        _weapon.Attack(direction);
    }

    private void Update()
    {
        currentDirection.z = 0;

        _weapon.transform.up = (currentDirection - transform.position).normalized;
    }

    private void OnGameEnd()
    {
        isGameEnded = true;
    }
}
