using UnityEngine;

[RequireComponent(typeof(IPhysically))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField][Min(0.01f)] private float _jumpForce;

    private PlayerInput _input;
    private IPhysically _physicsPlayer;
    private PlayerCamera _playerCamera;

    private void Awake()
    {
        _input = new PlayerInput();

        _input.Player.Jump.performed += context => Jump();
    }

    private void Start()
    {
        _physicsPlayer = GetComponent<IPhysically>();
        _input.Enable();
    }

    private void Jump()
    {
        if (_physicsPlayer?.IsGrounded ?? false)
            _physicsPlayer.Velocity = _jumpForce;
    }
}