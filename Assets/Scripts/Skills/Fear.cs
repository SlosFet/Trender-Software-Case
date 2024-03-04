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
        if (!canActivate || isGameEnded || !isGameStarted)
            return;

        //EnemyAI script has subscribed to it. When it toggle enemies goes backward
        ToggleFearSkill.Invoke(true);
        StartCoroutine(Countdowner());
        Invoke(nameof(DeactivateSkill), _skillActionTime);
        base.ActivateSkill();
    }

    private void DeactivateSkill()
    {
        ToggleFearSkill.Invoke(false);
    }
}
