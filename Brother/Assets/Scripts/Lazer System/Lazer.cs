using System;
using UnityEngine;

[RequireComponent(typeof(LazerView))]
public abstract class Lazer : MonoBehaviour
{
    public event Action<Vector3, Vector3, float> LazerSendRay;

    protected RaycastHit SendRay(Vector3 direction, Vector3 startPoint, float distanceRay)
    {
        Ray ray = new Ray(startPoint, direction);
        Debug.DrawRay(ray.origin, ray.direction);

        bool isFinded = Physics.Raycast(ray, out RaycastHit hit, distanceRay);

        if (isFinded == false)
            hit.distance = distanceRay;
        else
            TryUseObject(hit, ray, distanceRay - hit.distance);

        LazerSendRay?.Invoke(startPoint, direction, hit.distance);
        return hit;
    }
    private void TryUseObject(RaycastHit hit, Ray ray, float distanceRay)
    {
        if (hit.collider == null)
            return;

        bool isUsableObject = hit.collider.TryGetComponent(out ILazerUsable lazerUsable) ;

        if (isUsableObject)
            lazerUsable.Use(ray.direction, hit.normal, hit.point, distanceRay);
    }
}