using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows;

public class PlayerMovement
{
    private float _speed;

    private PlayerInput _input;
    private CharacterController _controller;
    private IPhysically _physically;

    private Transform _playerTransform;

    public PlayerMovement(float speed, PlayerInput input, CharacterController controller,
        IPhysically physically, ref Action fixedUpdate)
    {

        SetSpeed(speed);

        _input = input;
        _controller = controller;
        _physically = physically;
        _playerTransform = _controller.transform;
        fixedUpdate += Move;
    }
    public void SetSpeed(float newSpeed)
    {
        if (newSpeed <= 0)
            throw new Exception("Speed cannot be changed to negative!");

        _speed = newSpeed;
    } 
    private void Move()
    {
        Vector2 axisInput = _input.PlayerMovement.Move.ReadValue<Vector2>();

        Vector3 direction = new Vector3(axisInput.x, _physically.Velocity, axisInput.y);
        Vector3 forward = new Vector3(_playerTransform.forward * axisInput.y,, );

        _controller.Move(_speed * Time.fixedDeltaTime * forward);
    }
}