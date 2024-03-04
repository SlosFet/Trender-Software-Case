using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;
    public static event Action OnMoneyChange;

    [field : SerializeField] public float money { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        OnMoneyChange?.Invoke();
    }

    public void AddMoney(float value)
    {
        money += value;
        OnMoneyChange?.Invoke();
    }
}
