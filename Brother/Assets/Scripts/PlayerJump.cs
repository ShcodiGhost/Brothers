using System;
using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(IPhysically))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField][Min(0.01f)] private float _jumpForce;

    private PlayerInput _input;
    private IPhysically _physicsPlayer;

    private void Awake()
    {
        _input = new PlayerInput();
        _input.Player.Jump.performed += context => Jump();
    }

    private void OnEnable() => _input.Enable();
    private void Start() => _physicsPlayer = GetComponent<IPhysically>();
    private void OnDisable() => _input.Enable();

    private void Jump()
    {
        if (_physicsPlayer?.IsGrounded ?? false)
            _physicsPlayer.Velocity = _jumpForce;
    }
}
