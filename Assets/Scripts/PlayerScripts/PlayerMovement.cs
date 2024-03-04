using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [field: SerializeField] public Rigidbody2D _rb { get; private set; }
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Transform _mesh;

    private Vector2 moveDir;
    private bool canDoubleJump;
    private bool isGameEnded = false;

    //Checks if player is falling and not jumped. So set true canDoubleJump to jump again while falling(Ref from terraria)
    private bool hasJumped;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        InputManager.OnXAxisChange.AddListener(Move);
        InputManager.OnJumpButtonPressed.AddListener(Jump);
        GameManager.OnGameOver += OnGameEnd;
    }

    private void OnDisable()
    {
        InputManager.OnXAxisChange.RemoveListener(Move);
        InputManager.OnJumpButtonPressed.RemoveListener(Jump);
        GameManager.OnGameOver -= OnGameEnd;
    }

    private void Move(float direction)
    {
        if (isGameEnded)
            return;

        moveDir = new Vector2(direction * _speed, _rb.velocity.y);
        if (direction > 0)
            _mesh.localEulerAngles = Vector3.up * 0;
        else if (direction < 0)
            _mesh.localEulerAngles = Vector3.up * 180;

        _rb.velocity = moveDir;
    }

    private void Jump()
    {
        if (isGameEnded)
            return;

        if (_groundChecker.isGrounded || canDoubleJump)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            canDoubleJump = !canDoubleJump;
            hasJumped = true;


            CancelInvoke(nameof(SetJumpVariables));
            InvokeRepeating(nameof(SetJumpVariables), 0.2f, 0.2f);
        }
    }

    //Checks when player grounded set variables false also set canDoubleJump true if player is falling
    private void SetJumpVariables()
    {
        if (_groundChecker.isGrounded)
        {
            canDoubleJump = false;
            hasJumped = false;
        }

        if (!_groundChecker.isGrounded && !hasJumped)
            canDoubleJump = true;
    }

    private void OnGameEnd()
    {
        isGameEnded = true;
        _rb.velocity = Vector2.zero;
    }
}
