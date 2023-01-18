using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    
    public bool isDead = false;
    
    private ParticleSystem _deathParticles;
    private SpriteRenderer _renderer;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _deathParticles = GetComponentInChildren<ParticleSystem>();
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

    void Update()
    {
        if (CameraController.instance.IsTargetOffScreenBottom()) Kill();
        if (CameraController.instance.IsTargetOffScreenTop())
        {
            GameController.instance.win = true;
            Kill();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;
        var collided = other.gameObject.GetComponent<IEntity>();
        collided?.OnCollision();
    }

    public void Kill()
    {
        if (isDead) return;
        
        _deathParticles.Play();
        isDead = true;
        CameraController.instance.spectating = false;
        _renderer.enabled = false;
    }
}
