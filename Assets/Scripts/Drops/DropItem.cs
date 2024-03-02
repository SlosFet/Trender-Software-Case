using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public virtual void ActivateItemFeature()
    {
        Destroy(gameObject);
    }

}
