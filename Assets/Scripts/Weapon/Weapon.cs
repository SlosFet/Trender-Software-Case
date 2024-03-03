using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData weaponData;
    public bool coolDownOver;
    public bool isAttacking;
    public virtual void Attack(Vector3 direction)
    {
        if (!coolDownOver)
            return;
        StartCoroutine(CoolDownCounter());
        StartCoroutine(CoolDownCounter());
    }

    public IEnumerator CoolDownCounter()
    {
        coolDownOver = false;
        yield return new WaitForSecondsRealtime(weaponData.CooldownTime);
        coolDownOver = true;
    }

    public IEnumerator AttackDurationCountDowner()
    {
        isAttacking = true;
        yield return new WaitForSecondsRealtime(weaponData.attackDuration);
        isAttacking = false;
    }
}
