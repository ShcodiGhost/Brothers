using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGenerator : Lazer
{
    protected readonly float distanceRay = 1000000;

    private void Update()
    {
        SendRay(transform.forward, transform.position, distanceRay); 
    }
}
