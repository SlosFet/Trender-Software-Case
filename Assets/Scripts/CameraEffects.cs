using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraEffects : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _shakeForce;
    [SerializeField] private float _shakeDuration;

    private void Start()
    {
        _playerHealth.OnGetDamage += OnCameraShake;
    }

    private void OnCameraShake()
    {
        transform.DOComplete();
        transform.DOKill();
        transform.DOShakePosition(_shakeDuration, _shakeForce);
    }

}
