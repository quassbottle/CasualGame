using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Set in inspector")]
    public LayerMask wallsLayer;
    public Transform wallsCheck;
    [SerializeField] private int jumpsAmount = 2;
    [SerializeField] private float horizontalJumpForce = 2f;
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private float wallRadius = 0.1f;

    [Header("Set dynamically")] 
    [SerializeField] private bool _stickToWall = false;
    [SerializeField] private int _direction = 1;
    [SerializeField] private int _jumpsLeft;

    private Rigidbody2D _rigidbody;
    private float _gravityScale;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _gravityScale = _rigidbody.gravityScale;
        _jumpsLeft = jumpsAmount;
    }
    
    void Update()
    {
        MoveUpdate();
    }

    void MoveUpdate()
    {
        var velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y);
        _stickToWall = IsStickedToWall();

        if (_stickToWall)
        {
            velocity = new Vector2(velocity.x, 0);
            _rigidbody.gravityScale = 0;
            _jumpsLeft = jumpsAmount;
        }
        else _rigidbody.gravityScale = _gravityScale;
        
        if (Input.GetMouseButtonDown(0) && _jumpsLeft > 0 && !Player.instance.isDead)
        {
            velocity.y = jumpForce;
            velocity.x = horizontalJumpForce * _direction;
            _jumpsLeft--;
            Flip();
        }
        
        _rigidbody.velocity = velocity;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(wallsCheck.position, wallRadius);
    }

    private bool IsStickedToWall()
    {
        return Physics2D.OverlapCircle(wallsCheck.position, wallRadius, wallsLayer);
    }

    private void Flip()
    {
        _direction *= -1;
        var localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
