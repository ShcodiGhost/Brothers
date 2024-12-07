using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DirecterPlayer
{
    private float _sensitivity = 1f;

    private Transform _playerHead;
    private Transform _playerBody;
    
    public DirecterPlayer(DirectPlayerConfig playerConfig, PlayerInput input)
    {
        _playerHead = playerConfig.PlayerHead;
        _playerBody = playerConfig.PlayerBody;

        input.Mouse.MouseDelta.performed += DirectPlayer;
    }

    public void SetSensitivity(float newSensitivity)
    {
        if (newSensitivity <= 0)
            throw new Exception("Sensitivity cannot be changed to negative!");

        _sensitivity = newSensitivity;
    }

    private void DirectPlayer(InputAction.CallbackContext callback)
    {
        Vector2 MouseDelta = callback.ReadValue<Vector2>();

        Vector3 HeadRotation = Vector3.right * -MouseDelta.y;
        Vector3 BodyRotation = Vector3.up * MouseDelta.x;

        _playerBody.Rotate(BodyRotation * _sensitivity);
        _playerHead.Rotate(HeadRotation * _sensitivity);
    }
}