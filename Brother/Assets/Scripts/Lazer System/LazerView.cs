using System;
using System.Collections;
using System.Net;
using UnityEngine;
using UnityEngine.XR;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(LineRenderer), typeof(Lazer))]
public class LazerView : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Lazer _lazer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lazer = GetComponent<Lazer>();
        _lazer.LazerSendRay += ViewLazer;

        ChangeState(false);
    }

    private void OnEnable()
    {
        if(_lazer != null)
            _lazer.LazerSendRay += ViewLazer;
    }
    private void OnDisable()
    {
        if (_lazer != null)
            _lazer.LazerSendRay -= ViewLazer;
    }

    private void ViewLazer(Vector3 point, Vector3 direction, float distance)
    {
        ViewLine(point, point + (direction * distance));
    }
    private void ViewLine(Vector3 startPoint, Vector3 endPoint)
    {
        ChangeState(true);

        Vector3[] vertix = new Vector3[]
        {
            startPoint,
            endPoint
        };

        _lineRenderer.SetPositions(vertix);

        StartCoroutine(StopViewInNextFrame());
    }
    private void StopView()
    {
        ChangeState(false);
    }
    private IEnumerator StopViewInNextFrame()
    {
        yield return new WaitForEndOfFrame();
        StopView();
    }

    private void ChangeState(bool state)
    {
        _lineRenderer.enabled = state;

        Vector3[] vertix = new Vector3[0];
        _lineRenderer.SetPositions(vertix);
    }
}

