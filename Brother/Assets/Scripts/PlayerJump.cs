using UnityEngine;

[RequireComponent(typeof(IPhysically))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField][Min(0.01f)] private float _jumpForce;

    private IPhysically _physicsPlayer;

    private void OnEnable() => GoodInput.Input.Instance.Jump += Jump;
    private void Start() => _physicsPlayer = GetComponent<IPhysically>();
    private void OnDisable() => GoodInput.Input.Instance.Jump -= Jump;

    private void Jump()
    {
        if (_physicsPlayer.IsGrounded)
            _physicsPlayer.Velocity = _jumpForce;
    }
}
