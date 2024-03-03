using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkill : Skill
{
    [field:SerializeField] protected bool canActivate;

    protected IEnumerator Countdowner()
    {
        canActivate = false;

        float currentTime = Time.time;
        float desiredTime = Time.time + _coolDown;
        while (currentTime < desiredTime)
        {
            currentTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        canActivate = true;
        yield break;
    }
}
