using UnityEngine.InputSystem;

public class PlayerJump
{
    private float _jumpForce;
    private IPhysically _physicsPlayer;

    public PlayerJump(float jumpForce, IPhysically physics, PlayerInput input)
    {
        _jumpForce = jumpForce;
        _physicsPlayer = physics;

        input.Player.Jump.performed += Jump;
    }

    private void Jump(InputAction.CallbackContext callback)
    {
        if (_physicsPlayer?.IsGrounded ?? false)
            _physicsPlayer.Velocity = _jumpForce;
    }
}