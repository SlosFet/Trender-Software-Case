using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField] private DropList _data;
    public void GetDrop()
    {
        DropManager.Instance.GetDrop(transform.position,_data._items);
    }
}
