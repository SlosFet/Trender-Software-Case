using System;
using System.Collections;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [field: SerializeField] public float _coolDown { get; private set; }
    [field: SerializeField] protected bool canActivate;

    public event Action OnSkillActivated;
    public event Action OnSkillActivateable;
    public event Action<float> OnSkillLoading;

    protected bool isGameEnded = false;
    protected bool isGameStarted = false;

    private void OnEnable()
    {
        GameManager.OnGameOver += OnGameEnd;
        GameManager.OnGameStarted += OnGameStart;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= OnGameEnd;
        GameManager.OnGameStarted -= OnGameStart;
    }
    private void Start()
    {
        canActivate = true;
    }
    public virtual void ActivateSkill()
    {
        if (isGameEnded || !isGameStarted)
            return;

        OnSkillActivated?.Invoke();
    }

    protected virtual IEnumerator Countdowner()
    {
        canActivate = false;
        print(4444);
        float currentTime = Time.time;
        float desiredTime = Time.time + _coolDown;
        while (currentTime < desiredTime)
        {
            currentTime += Time.deltaTime;
            float progressPercent = (desiredTime - currentTime) / _coolDown;
            OnSkillLoading?.Invoke(progressPercent);
            yield return new WaitForEndOfFrame();
        }
        OnSkillActivateable?.Invoke();
        canActivate = true;
        yield break;
    }

    //Not using for now but if there will be some upgrade like VampireSurvivors can use this
    public void UpgradeSkillCountDown(float newCoolDown)
    {
        CancelInvoke(nameof(ActivateSkill));
        InvokeRepeating(nameof(ActivateSkill), 0, newCoolDown);
    }

    private void OnGameEnd()
    {
        isGameEnded = true;
    }

    protected virtual void OnGameStart()
    {
        isGameStarted = true;
    }
}
