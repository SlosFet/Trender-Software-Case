using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private float _distance;
    [SerializeField] private Transform _rayPoint;
    [SerializeField] private LayerMask _desiredLayers;
    private Rigidbody2D targetsRb;
    public override void Attack(Vector3 direction)
    {
        if (!coolDownOver)
            return;

        RaycastHit2D hitInfo = Physics2D.Raycast(_rayPoint.position, direction, _distance, _desiredLayers);

        if(hitInfo)
        {
            if (hitInfo.collider.attachedRigidbody)
                targetsRb = hitInfo.collider.attachedRigidbody;
        }

        if (targetsRb != null)
            if (targetsRb.TryGetComponent(out Damageable damageable))
            {
                damageable.GetDamage(weaponData.Damage);
            }

        base.Attack(direction);
    }
}
