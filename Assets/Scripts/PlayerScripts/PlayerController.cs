using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerHealth playerHealth;
    PlayerWeaponManager playerWeaponManager;
    PlayerAnimController playerAnimController;
    PlayerMovement playerMovement;

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

    }

    private void Update()
    {
        
    }
}
