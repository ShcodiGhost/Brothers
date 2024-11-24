using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPhysically
{
    public bool IsGrounded { get; }
    public float Velocity { get; set; }
}
