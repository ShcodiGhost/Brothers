using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

public class ReflexionLazer : Lazer, ILazerUsable
{
    private void ReflexLazer(Vector3 lazerDirection, Vector3 normal, Vector3 point, float distanceRay)
    {
        Vector3 reflexLazerDirection = Vector3.Reflect(lazerDirection.normalized, normal);
         
        SendRay(reflexLazerDirection, point, distanceRay);
    }
    public void Use(Vector3 lazerDirection, Vector3 normal, Vector3 point, float distanceRay)
    {
        ReflexLazer(lazerDirection, normal, point, distanceRay);
    }
}
