using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PathRenderer : MonoBehaviour
{
    public bool loop;
    private Transform[] _points;
    private LineRenderer _lineRenderer;
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.loop = loop;
        
        var nodes = GetComponentsInChildren<PathNode>();
        _points = new Transform[nodes.Length];
        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = nodes[i].transform;
        }
        
        _lineRenderer.positionCount = _points.Length;
    }

    void Update()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            _lineRenderer.SetPosition(i, _points[i].position);
        }
    }
}
