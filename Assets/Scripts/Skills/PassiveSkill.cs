using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSkill : Skill
{
    void Start()
    {
        InvokeRepeating(nameof(ActivateSkill), 0, _coolDown);   
    }

    //Not using for now but if there will be some upgrade like VampireSurvivors can use this
    public void UpgradeSkillCountDown(float newCoolDown)
    {
        CancelInvoke(nameof(ActivateSkill));
        InvokeRepeating(nameof(ActivateSkill), 0, newCoolDown);
    }
}
