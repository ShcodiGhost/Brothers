using System;
using UnityEngine;

[RequireComponent(typeof(IPhysically), typeof(CharacterController))]
public class PlayerDI : MonoBehaviour
{
    [SerializeField] private PlayerMovementConfig _playerMovementConfig;
    [SerializeField] private DirectPlayerConfig _directPlayerConfig;

    private PlayerMovement _playerMovement;
    private PlayerJump _playerJump;
    private DirecterPlayer _playerDirecter;

    private PlayerInput _input;
    private event Action _fixedUpdate;
    private bool _isInstanse;

    private void OnEnable()
    {
        if (_isInstanse == false)
            return;

        _input.Enable();
    }
    private void Start()
    {
        IPhysically playerPhysical = GetComponent<IPhysically>();
        CharacterController characterController = GetComponent<CharacterController>();

        _input = new PlayerInput();

        _playerJump = new PlayerJump(_playerMovementConfig.JumpForce, playerPhysical, _input);
        _playerMovement = new PlayerMovement(_playerMovementConfig.Speed,
                                             _input,
                                             characterController,
                                             playerPhysical,
                                             _fixedUpdate);

        _playerDirecter = new DirecterPlayer(_directPlayerConfig, _input);

        _isInstanse = true;
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
    }
    private void FixedUpdate() => _fixedUpdate?.Invoke();
}
