using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMovement
{
    private float _speed;

    private PlayerInput _input;
    private CharacterController _controller;
    private IPhysically _physically;

    public PlayerMovement(float speed, PlayerInput input, CharacterController controller, IPhysically physically, Action fixedUpdate)
    {
        SetSpeed(speed);

        _input = input;
        _controller = controller;
        _physically = physically;

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
        _controller.Move(direction * _speed * Time.deltaTime);
    }
}