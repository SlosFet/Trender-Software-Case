using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    [SerializeField] private float _money;

    private void Awake()
    {
        Instance = this;
    }

    public void AddMoney(float value)
    {
        _money += value;
    }
}
