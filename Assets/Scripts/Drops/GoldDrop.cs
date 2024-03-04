using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldDrop : DropItem
{
    //Inherits from DropItem and handles itself's function

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
