using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField] private DropList _data;
    [SerializeField] private int _dropChancePercent;
    public void GetDrop()
    {
        if (Random.Range(0, 100) >= _dropChancePercent)
            return;


        DropManager.Instance.GetDrop(transform.position,_data._items[Random.Range(0,_data._items.Count)]);
    }
}
