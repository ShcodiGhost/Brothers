using System;
using UnityEngine;

[Serializable]
public class PlayerMovementConfig
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    public float Speed => _speed;
    public float JumpForce => _jumpForce;
}
