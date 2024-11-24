using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IPhysically), typeof(CharacterController))]
public class PlayerMoverInjector : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField][Min(0.01f)] private float _jumpForce;

    [Header("Movement")]
    [SerializeField][Min(0.01f)] private float _moveSpeed;


    private PlayerJump _playerJump;
    private PlayerMovement _playerMovement;
    private PlayerInput _playerInput;

    private void Start()
    {
        CharacterController characterController = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
        IPhysically physically = GetComponent<IPhysically>();

        _playerJump = new PlayerJump(_jumpForce, _playerInput, physically);
        _playerMovement = new PlayerMovement(_moveSpeed, _playerInput);
    }
    private void OnEnable() => _playerInput.Enable();
    private void OnDisable() => _playerInput.Disable();
}
