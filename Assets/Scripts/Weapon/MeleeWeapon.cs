using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private float _distance;
    [SerializeField] private Transform _rayPoint;
    public override void Attack(Vector3 direction)
    {
        if (!coolDownOver)
            return;

        Rigidbody2D rb = Physics2D.Raycast(_rayPoint.position, direction, _distance).collider.attachedRigidbody;

        if (rb != null)
            if (rb.TryGetComponent(out Damageable damageable))
            {
                damageable.GetDamage(weaponData.Damage);
            }

        base.Attack(direction);
    }
}
