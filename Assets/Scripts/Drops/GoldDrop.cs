using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldDrop : DropItem
{
    [SerializeField] private GoldDropData data;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody && collision.attachedRigidbody.gameObject.CompareTag("Player"))
        {
            ActivateItemFeature();
        }
    }

    public override void ActivateItemFeature()
    {
        MoneyManager.Instance.AddMoney(data.gold);
        base.ActivateItemFeature();
    }
}
