using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(CharacterController), typeof(IPhysically))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField][Min(0.01f)] private float _speed;

    private PlayerInput _input;
    private CharacterController _controller;
    private IPhysically _physically;

    private void Awake() => _input = new PlayerInput();
    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _physically = GetComponent<IPhysically>();
        _input.Enable();
    }

    private void FixedUpdate()
    {
        Move(_input.Player.Move.ReadValue<Vector2>().normalized);
        Debug.Log(_input.Player.Move.ReadValue<Vector2>().normalized);
    }


    private void Move(Vector2 directionNormalized)
    {
        Vector3 normal = new Vector3(directionNormalized.x, _physically.Velocity, directionNormalized.y) * Time.fixedDeltaTime;
        _controller.Move(normal * _speed);
    }
}