using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSkill : Skill
{
    private void Start()
    {
        canActivate = true;
        StartCoroutine(Countdowner());
    }
    protected override IEnumerator Countdowner()
    {
        while(true)
        {
            ActivateSkill();
            StartCoroutine(base.Countdowner());
            yield return new WaitForSecondsRealtime(_coolDown);
        }
     
    }


}
