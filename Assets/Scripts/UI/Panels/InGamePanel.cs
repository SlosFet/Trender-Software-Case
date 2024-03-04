using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGamePanel : UIPanel
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Image _healthBar;
    [SerializeField] private TextMeshProUGUI _coinCounter;
    private float _healthBarValue;

    private void OnEnable()
    {
        _playerHealth.OnGetHeal += SetHealthBar;
        _playerHealth.OnGetDamage += SetHealthBar;
        MoneyManager.OnMoneyChange += SetCoinCounter;
    }

    private void OnDisable()
    {
        _playerHealth.OnGetHeal -= SetHealthBar;
        _playerHealth.OnGetDamage -= SetHealthBar;
        MoneyManager.OnMoneyChange -= SetCoinCounter;
    }

    private void SetHealthBar()
    {
        _healthBarValue = _playerHealth._health / _playerHealth._maxHealth;
        _healthBar.fillAmount = _healthBarValue;
    }

    private void SetCoinCounter()
    {
        _coinCounter.text = MoneyManager.Instance.money.ToString();
    }
}
