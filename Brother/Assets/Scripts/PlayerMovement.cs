using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField][Min(0.01f)] private float _speed;

    private void FixedUpdate()
    {
    }
}
