using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEye : MonoBehaviour
{
    public float flightSpeed = 2f;
    public DetectionZone zone;
    Animator animator;
    Rigidbody2D rb;
    public List<Transform> waypoints;
    Damageable damageable;
    int waypointNum = 0;
    Transform nextWaypoint;
    public float waypointReachedDistance = 0.1f;
    public Collider2D deathCollider;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        damageable = GetComponent<Damageable>();
    }

    private void Start()
    {
        nextWaypoint = waypoints[waypointNum];

    }

    private void OnEnable()
    {
        damageable.deathEvent.AddListener(OnDeath);
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

   
    void Update()
    {
        HasTarget = zone.detectedColliders.Count > 0;
    }

    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }

    private void FixedUpdate()
    {
        if(damageable.IsAlive)
        {
            if(CanMove)
            {
                Flight();
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    private void Flight()
    {
        //Fly to the next waypoint
        Vector2 direction = (nextWaypoint.position - transform.position).normalized;

        //check distance
        float distance = Vector2.Distance(nextWaypoint.position, transform.position);

        rb.velocity = direction * flightSpeed;
        UpdateDir();

        if (distance <= waypointReachedDistance)
        {
            //switch waypoint
            waypointNum++;

            if(waypointNum >= waypoints.Count)
            {
                //loop back to original waypoint
                waypointNum = 0;
            }
            nextWaypoint = waypoints[waypointNum];
        }
    }

    private void UpdateDir()
    {

        Vector3 localScale = transform.localScale;
        if(transform.localScale.x > 0)
        {
            if(rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1*localScale.x, localScale.y,localScale.z);
            }
        }
        else
        {
            if (rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(-1 * localScale.x, localScale.y, localScale.z);
            }
        }
    }

    public void OnDeath()
    {
        //he ded
        rb.gravityScale = 2f;
        rb.velocity = new Vector2(0, rb.velocity.y);
        deathCollider.enabled = true;
    }
}
