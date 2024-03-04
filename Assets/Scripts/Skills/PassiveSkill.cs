using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSkill : Skill
{
    protected override IEnumerator Countdowner()
    {
        while(!isGameEnded)
        {
            ActivateSkill();
            StartCoroutine(base.Countdowner());
            yield return new WaitForSecondsRealtime(_coolDown);
        }
    }

    protected override void OnGameStart()
    {
        base.OnGameStart();
        canActivate = true;
        StartCoroutine(Countdowner());
    }

}
