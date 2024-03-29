using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData weaponData;
    public bool coolDownOver;
    public virtual void Attack(Vector3 direction)
    {
        if (!coolDownOver)
            return;
        StartCoroutine(CoolDownCounter());
    }

    public IEnumerator CoolDownCounter()
    {
        coolDownOver = false;
        yield return new WaitForSecondsRealtime(weaponData.CooldownTime);
        coolDownOver = true;
    }
}
