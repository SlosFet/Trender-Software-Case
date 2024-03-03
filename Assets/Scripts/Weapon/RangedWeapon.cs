using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] private ThrowableObject _missile;
    [SerializeField] private Transform _shootPos;
    [SerializeField] private float _shootForce;
    public override void Attack(Vector3 direction)
    {
        if (!coolDownOver)
            return;

        ThrowableObject missile = Instantiate(_missile.gameObject, _shootPos.position, Quaternion.identity).GetComponent<ThrowableObject>();
        missile.OnShoot(direction, _shootForce, weaponData.Damage);
        base.Attack(direction);
    }
}
