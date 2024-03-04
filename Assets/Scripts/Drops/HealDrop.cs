using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealDrop : DropItem
{
    //Inherits from DropItem and handles itself's function

    [SerializeField] private HealDropData data;
    private Damageable damageable;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody && collision.attachedRigidbody.gameObject.CompareTag("Player"))
        {
            damageable = collision.attachedRigidbody.gameObject.GetComponent<Damageable>();
            ActivateItemFeature();
        }
    }

    public override void ActivateItemFeature()
    {
        damageable.GetHeal(data.healAmount);
        base.ActivateItemFeature();
    }
}
