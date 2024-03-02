using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealDrop : DropItem
{
    [SerializeField] private HealDropData data;
    private Damageable damageable;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody && collision.attachedRigidbody.gameObject.CompareTag("Player"))
        {
            damageable = collision.attachedRigidbody.gameObject.GetComponent<Damageable>();
        }
    }

    public override void ActivateItemFeature()
    {
        damageable.GetHeal(data.healAmount);
        base.ActivateItemFeature();
    }
}
