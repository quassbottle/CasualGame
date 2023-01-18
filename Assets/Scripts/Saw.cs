using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour, IEntity
{
    [Header("Set in inspector")]
    public float scale = 1;
    
    void Start()
    {
        transform.localScale = new Vector2(scale, scale);
    }

    public void OnCollision()
    {
        Player.instance.Kill();
    }
}
