using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [field:SerializeField] public float _coolDown { get; private set; }
    private bool canActivate = false;
    public virtual void ActivateSkill()
    {

    }

}
