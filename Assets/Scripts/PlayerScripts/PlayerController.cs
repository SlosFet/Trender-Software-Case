using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerHealth playerHealth;
    PlayerWeaponManager playerWeaponManager;
    PlayerAnimController playerAnimController;
    PlayerMovement playerMovement;
    [SerializeField] private GameObject _mesh;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerWeaponManager = GetComponent<PlayerWeaponManager>();
        playerAnimController = GetComponent<PlayerAnimController>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        playerHealth.OnGetDamage += playerAnimController.HitAnim;
        playerHealth.OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        _mesh.SetActive(false);
        GameManager.Instance.GameOver();
    }
}
