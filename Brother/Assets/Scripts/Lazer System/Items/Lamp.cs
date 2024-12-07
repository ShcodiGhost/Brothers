using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, ILazerUsable
{
    
    private bool _enable;
    public void Use(Vector3 lazerDirection, Vector3 normal, Vector3 point, float distanceRay)
    {

    }
    private void Enable()
    {

    }
    private void ChangeState(bool state)
    {
        _enable = state;
    }
}
