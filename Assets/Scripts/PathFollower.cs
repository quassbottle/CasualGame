using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {
    public float speed = 1;
    public bool loop = false;
    public Transform[] target;

    private int _current;
    private int _move;

    void Start()
    {
        transform.position = target[0].transform.position;
    }

    private void Update()
    {
        if (transform.position != target[_current].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, target[_current].position, Time.deltaTime * speed);
        }
        else
        {
            if (loop) _current = (_current + 1) % target.Length;
            else
            {
                if (_current == 0) _move = 1;
                if (_current == target.Length - 1) _move = -1;
                
                _current += _move;
            }
        }
    }
}
