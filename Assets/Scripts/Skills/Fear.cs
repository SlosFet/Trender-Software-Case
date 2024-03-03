using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fear : ActiveSkill
{
    public static UnityEvent<bool> ToggleFearSkill = new UnityEvent<bool>();
    [SerializeField] private float _skillActionTime;
    public override void ActivateSkill()
    {
        if (!canActivate)
            return;

        ToggleFearSkill.Invoke(true);
        StartCoroutine(Countdowner());
        Invoke(nameof(DeactivateSkill), _skillActionTime);
    }

    private void DeactivateSkill()
    {
        ToggleFearSkill.Invoke(false);
    }
}
