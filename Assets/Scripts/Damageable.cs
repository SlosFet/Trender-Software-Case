using UnityEngine;
using System;
public abstract class Damageable : MonoBehaviour
{
    [field: SerializeField] public float _health { get; private set; }
    [field: SerializeField] public float _maxHealth { get; private set; }
    public bool isDeath;

    public event Action OnDeath;
    public event Action OnGetHeal;
    public event Action OnGetDamage;

    public virtual void GetDamage(float damageAmount)
    {
        if (isDeath)
            return;

        SetHealth(-damageAmount);
        OnGetDamage?.Invoke();
    }

    public virtual void GetHeal(float HealAmount)
    {
        SetHealth(HealAmount);
        //When player die it don't invoke;
        if (_health > 0)
            OnGetHeal?.Invoke();
    }

    private void SetHealth(float value)
    {
        _health += value;
        _health = Mathf.Clamp(_health, 0, _maxHealth);

        if (_health <= 0)
            Death();
    }

    protected virtual void Death()
    {
        isDeath = true;
        OnDeath?.Invoke();
    }
}
