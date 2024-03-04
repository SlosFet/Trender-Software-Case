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

        direction = (direction - transform.position).normalized;
        _weapon.Attack(direction);
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        _weapon.transform.up = (mousePosition - transform.position).normalized;
    }

    private void OnGameEnd()
    {
        isGameEnded = true;
    }
}
