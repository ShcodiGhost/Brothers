using UnityEngine;
using UnityEngine.InputSystem;

public class DirectPlayer
{
    private float _sensitivity;

    private Transform _playerHead;
    private Transform _playerBody;

    public DirectPlayer(Transform playerHead, Transform playerBody, PlayerInput input)
    {
        _playerHead = playerHead;
        _playerBody = playerBody;

        input.Player.MouseDelta.performed += CameraLookAt;
    }

    private void CameraLookAt(InputAction.CallbackContext callback)
    {
        Vector2 MouseDelta = callback.ReadValue<Vector2>();

        Vector3 HeadRotation = Vector3.forward * MouseDelta.y;
        Vector3 BodyRotation = Vector3.up * MouseDelta.x;

        _playerBody.Rotate(BodyRotation * _sensitivity);
        _playerHead.Rotate(HeadRotation * _sensitivity);
    }
}