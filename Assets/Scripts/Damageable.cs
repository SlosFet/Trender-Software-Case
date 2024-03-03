using UnityEngine;
using System;
public class Damageable : MonoBehaviour
{
    [field: SerializeField] protected float _health;
    [field: SerializeField] protected float _maxHealth;
    public bool isDeath;

    public event Action OnDeath;

    public void GetDamage(float damageAmount)
    {
        SetHealth(-damageAmount);
    }

    public void GetHeal(float HealAmount)
    {
        SetHealth(HealAmount);
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
        OnDeath();
    }
}
