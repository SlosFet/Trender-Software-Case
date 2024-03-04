using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    //Drop stuffs handles in here

    public static DropManager Instance;

    [SerializeField] private DropList _data;

    private void Awake()
    {
        Instance = this;
    }

    //if there will a contains everything enemy (like current enemies :D) they can use it
    public void GetDropRandom(Vector3 pos)
    {
        DropItem item = _data._items[Random.Range(0, _data._items.Count)];
        Instantiate(item.gameObject, pos, Quaternion.identity);
    }

    //For one item
    public void GetDrop(Vector3 pos,DropItem item)
    {
        Instantiate(item.gameObject, pos, Quaternion.identity);
    }

    //For multiple but not using now
    public void GetDrop(Vector3 pos, List<DropItem> items)
    {
        foreach (var item in items)
        {
            Instantiate(item.gameObject, pos, Quaternion.identity);
        }
    }
}
