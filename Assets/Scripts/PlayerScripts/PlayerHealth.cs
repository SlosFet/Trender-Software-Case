using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Damageable
{
    public event Action onGetDamage;
    public override void GetDamage(float damageAmount)
    {
        onGetDamage();
        base.GetDamage(damageAmount);

    }
}
