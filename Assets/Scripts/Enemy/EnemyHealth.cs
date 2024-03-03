using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Damageable
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D collider;

    protected override void Death()
    {
        rb.simulated = false;
        collider.isTrigger = true;
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
