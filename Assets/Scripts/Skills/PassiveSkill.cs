using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSkill : Skill
{
    void Start()
    {
        InvokeRepeating(nameof(ActivateSkill), 0, _coolDown);   
    }
}
