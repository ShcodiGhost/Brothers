using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILazerUsable
{
    public abstract void Use(Vector3 lazerDirection, Vector3 normal, Vector3 point, float distanceRay);
}
