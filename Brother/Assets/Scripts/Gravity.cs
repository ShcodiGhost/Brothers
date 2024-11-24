using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Gravity : MonoBehaviour, IPhysically
{
    [SerializeField][Min(0.08f)] private float _maxDistance;

    private bool _isGrounded;
    private float _gravity = 9.81f;
    private float _defaultVelocity = -2;
    private float _velocity;
    
    private CharacterController _controller;

    public bool IsGrounded => _isGrounded;
    public float Velocity { get => _velocity; set => _velocity = value; }

    private bool CheckIsGrounded =>
        Physics.BoxCast(_controller.bounds.center, _controller.bounds.size / 2,
            Vector3.down, Quaternion.identity, _maxDistance);

    private void Start() => _controller = GetComponent<CharacterController>();
    private void FixedUpdate()
    {
        bool isGrounded = CheckIsGrounded;
        _isGrounded = isGrounded;

        DoGravity();

        if (isGrounded == true)
            _velocity = _defaultVelocity;
    }
    private void DoGravity()
    {
        _velocity -= _gravity * Time.fixedDeltaTime;
        _controller.Move(Vector3.up * _velocity * Time.fixedDeltaTime);
    }
}