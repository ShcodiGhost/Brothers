using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement
{
    [SerializeField][Min(0.01f)] private float _speed;

    private PlayerInput _input;
    private CharacterController _controller;
    private IPhysically _physically;

    public PlayerMovement(float speed, PlayerInput input, CharacterController controller, IPhysically physically)
    {
        
        input 

        _controller = controller;
        _physically = physically;
    }

    private void Awake() => _input = new PlayerInput();
    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _physically = GetComponent<IPhysically>();
    }

    private void FixedUpdate()
    {
        Move(_input.Player.Move.ReadValue<Vector2>().normalized);
    }


    private void Move(Vector2 directionNormalized)
    {
        Vector3 normal = new Vector3(directionNormalized.x, _physically.Velocity, directionNormalized.y) * Time.fixedDeltaTime;
        _controller.Move(normal * _speed);
    }
}