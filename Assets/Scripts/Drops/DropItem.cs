using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DropItem : MonoBehaviour
{
    //Function for inherit classes
    public virtual void ActivateItemFeature()
    {
        Destroy(gameObject);
    }

}
