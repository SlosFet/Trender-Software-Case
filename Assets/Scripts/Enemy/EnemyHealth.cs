using System;
using UnityEngine;

public class EnemyHealth : Damageable
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D collider;

    public static event Action increaseDeathCount;
    protected override void Death()
    {
        rb.simulated = false;
        collider.isTrigger = true;
        increaseDeathCount?.Invoke();
        base.Death();
    }

    public void OnSpawn()
    {
        rb.simulated = true;
        collider.isTrigger = false;
        GetHeal(_maxHealth);
        isDeath = false;
    }
}
