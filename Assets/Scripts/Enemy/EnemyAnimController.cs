using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimController : MonoBehaviour
{
    [SerializeField] private string Idle;
    [SerializeField] private string Move;
    [SerializeField] private string Jump;
    [SerializeField] private string Fall;
    [SerializeField] private string Hit;

    [SerializeField] private Animator _animator;
    private Rigidbody2D rb;

    //Dependency Injection
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        if (_animator.GetBool(Hit))
            return;

        _animator.SetBool(Idle, Mathf.Abs(rb.velocity.magnitude) == 0);
        MoveAnim();
        JumpAnim();
        FallAnim();
    }
    private void MoveAnim()
    {
        _animator.SetBool(Move, Mathf.Abs(rb.velocity.x) > 0 && Mathf.Abs(rb.velocity.y) <= .3f);
    }

    private void JumpAnim()
    {
        _animator.SetBool(Jump, rb.velocity.y > 0);
    }

    private void FallAnim()
    {
        _animator.SetBool(Fall, rb.velocity.y < 0);
    }

    public void HitAnim()
    {
        if (_animator.GetBool(Hit))
            return;

        _animator.SetBool(Hit, true);
        Invoke(nameof(SetHitFalse), .3f);
    }

    public void AttackAnim()
    {
        
    }

    public void SetHitFalse()
    {
        _animator.SetBool(Hit, false);
    }
}
