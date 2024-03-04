using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DropList",menuName = "DropLists/DropList")]
public class DropList : ScriptableObject
{
    //Contains an enemy's or object's(There is no object for now) drop list and send it to dropManager when drop activate
    public List<DropItem> _items;
}
