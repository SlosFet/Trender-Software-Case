using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] private string Idle;
    [SerializeField] private string Move;
    [SerializeField] private string Jump;
    [SerializeField] private string Fall;

    private Animator _animator;
    private PlayerMovement playerMovement;

    //Dependency Injection
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        _animator.SetBool(Idle, Mathf.Abs(playerMovement._rb.velocity.magnitude) == 0);
        MoveAnim();
        JumpAnim();
        FallAnim();
    }
    private void MoveAnim()
    {
        _animator.SetBool(Move, Mathf.Abs(playerMovement._rb.velocity.x) > 0 && Mathf.Abs(playerMovement._rb.velocity.y) <= .3f);
    }

    private void JumpAnim()
    {
        _animator.SetBool(Jump, playerMovement._rb.velocity.y > 0);
    }

    private void FallAnim()
    {
        _animator.SetBool(Fall, playerMovement._rb.velocity.y < 0);
    }
}
