using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DropList",menuName = "DropLists/DropList")]
public class DropList : ScriptableObject
{
    public List<DropItem> _items;
}
