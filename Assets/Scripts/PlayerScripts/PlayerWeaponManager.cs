using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    private bool isGameEnded = false;
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
        direction.z = 0;

        SetDirection(direction);
        direction = (direction - transform.position).normalized;
        print(direction);
        _weapon.Attack(direction);
    }

    private void SetDirection(Vector3 direction)
    {
        _weapon.transform.up = (direction - transform.position).normalized;
    }

    private void OnGameEnd()
    {
        isGameEnded = true;
    }
}
