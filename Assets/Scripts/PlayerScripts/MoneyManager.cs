using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;
    public static event Action<float> OnMoneyChange;

    [field : SerializeField] public float _money { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        OnMoneyChange?.Invoke(_money);
    }

    public void AddMoney(float value)
    {
        _money += value;
        OnMoneyChange?.Invoke(_money);
    }
}
