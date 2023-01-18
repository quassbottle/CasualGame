using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    
    public GameObject target;
    public float smoothing = 5f;
    public bool spectating = true;
    
    //private Vector3 _pos;
    //private float _moveDistanceX;
    //private float _moveDistanceY;
    private Vector3 _offset;
    private float _lastY;

    private void Start()
    {
        //_pos = target.transform.position;
        _offset = transform.position - target.transform.position;
    }
    
    private void Awake()
    {
        InitSingleton();
    }
    private void InitSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool IsTargetOffScreenBottom()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(target.transform.position);
        return viewPos.y <= 0;
    }

    public bool IsTargetOffScreenTop()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(target.transform.position);
        return viewPos.y >= 1;
    }

    private void FixedUpdate()
    {
        if (spectating)
        {
            // _moveDistanceX = spectatable.transform.position.x - _pos.x;
            // _moveDistanceY = spectatable.transform.position.y - _pos.y;
            //
            // transform.position = new Vector3(transform.position.x + _moveDistanceX, transform.position.y + _moveDistanceY,
            //     transform.position.z);
            //
            // _pos = spectatable.transform.position;
            _lastY = Mathf.Min(GameController.instance.maxY, Mathf.Max(_lastY, target.transform.position.y));
            var position = target.transform.position + _offset;
            position = Vector3.Lerp(transform.position, position, smoothing * Time.deltaTime);
            transform.position = new Vector3(position.x, _lastY, position.z);
        }
    }
}