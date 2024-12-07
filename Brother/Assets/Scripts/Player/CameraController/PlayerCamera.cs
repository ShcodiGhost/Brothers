using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;

    private Transform _player;
    private PlayerInput _input;
    
    private void Awake()
    {
        _input = new PlayerInput();
        _player = transform;

        _input.Player.MouseDelta.performed += CameraLookAt;

        _input.Enable();
    }

    private void CameraLookAt(InputAction.CallbackContext callback)
    {
        Vector3 worldPoint = callback.ReadValue<Vector2>();

        Debug.Log(worldPoint);

        Vector3 x = new Vector3(0, worldPoint.x, 0);
        _player.Rotate(x);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(_player.position, _playerCamera.ScreenToWorldPoint(_input.Player.MouseDelta.ReadValue<Vector2>().normalized));
    }
}