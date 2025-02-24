using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Rigidbody2D rb;
    public float walkAcceleration = 3f;
    public float maxSpeed = 3f;
    public DetectionZone attackZone;
    public DetectionZone cliff;
    Animator animator;
    TouchingDirections td;
    public float walkStopRate = 0.6f;
    Damageable damageable;

    public enum WalkableDirections { Right, Left};

    private WalkableDirections _walkDirections;
    private Vector2 dir = Vector2.right;


    public WalkableDirections WalkDirections
    {
        get { return _walkDirections; }
        set {
            if(_walkDirections != value) 
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x*-1,gameObject.transform.localScale.y);

                if(value == WalkableDirections.Right)
                {
                    dir = Vector2.right;
                }
                else if(value == WalkableDirections.Left)
                {
                    dir = Vector2.left;
                }
            
            }

            _walkDirections = value; }
    }

    public bool _hasTarget = false;
    public bool HasTarget 
    {
        get
        {
            return _hasTarget;
        }

        private set
        {
            _hasTarget = value;
            animator.SetBool(AnimationStrings.hasTarget, value);
        }
    }

    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }

    public float AttackCooldown
    {
        get
        {
            return animator.GetFloat(AnimationStrings.attackCooldown);
        }
        private set
        {
            animator.SetFloat(AnimationStrings.attackCooldown, Mathf.Max(value, 0));
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        td = GetComponent<TouchingDirections>();
        animator = GetComponent<Animator>();
        damageable = GetComponent<Damageable>();
    }
    void Update()
    {
        HasTarget = attackZone.detectedColliders.Count > 0;
        if(AttackCooldown > 0)
        {
            AttackCooldown -= Time.deltaTime;
        }
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(td.IsGrounded && td.IsOnWall)
        {
            FlipDirection();
        }

        if (!damageable.LockVelocity)
        {
            if (CanMove && td.IsGrounded)
            {

                rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x + (walkAcceleration * dir.x * Time.deltaTime), -maxSpeed, maxSpeed), rb.velocity.y);
            }
                
            else
            {
                rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, walkStopRate), rb.velocity.y);
            }
        }
    }

    private void FlipDirection()
    {
        if(WalkDirections == WalkableDirections.Right)
        {
            WalkDirections = WalkableDirections.Left;
        }
        else if(WalkDirections == WalkableDirections.Left)
        { WalkDirections = WalkableDirections.Right;}
        else
        {
            Debug.Log("Error");
        }
    }

    public void OnHit(int damage, Vector2 knockback )
    {
        
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }

    public void OnCliff()
    {
        if (td.IsGrounded)
        {
            FlipDirection();
        }
    }
}
