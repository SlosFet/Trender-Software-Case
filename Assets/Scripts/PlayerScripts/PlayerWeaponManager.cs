using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private void OnEnable()
    {
        InputManager.OnAttack.AddListener(Attack);
    }

    private void OnDisable()
    {
        InputManager.OnAttack.RemoveListener(Attack);
    }

    private void Attack(Vector3 direction)
    {
        direction = (direction - transform.position).normalized;
        _weapon.Attack(direction);
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        _weapon.transform.up = (mousePosition - transform.position).normalized;
    }
}
