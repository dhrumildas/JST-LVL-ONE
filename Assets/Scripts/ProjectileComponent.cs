using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
    public int damage = 7;
    public Vector2 moveSpeed = new Vector2(3f, 0);
    public Vector2 knockBack = new Vector2(0, 0);
    public float destroyDelay = 2.5f; // Step 1: Public variable for delay time

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.velocity = new Vector2(moveSpeed.x * transform.localScale.x, moveSpeed.y);
        StartCoroutine(DestroyAfterTime(destroyDelay)); // Step 2: Use the variable in the coroutine
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle interaction with enemies
        Damageable damageable = collision.GetComponent<Damageable>();

        if (damageable != null)
        {
            Vector2 deliveredKnockback = transform.localScale.x > 0 ? knockBack : new Vector2(-knockBack.x, knockBack.y);
            bool gotHit = damageable.Hit(damage, deliveredKnockback);

            if (gotHit)
            {
                Debug.Log(collision.name + " hit for " + damage);
                Destroy(gameObject);
            }
        }
        else
        {
            // Destroy the projectile if it hits anything else (like the ground)
            Destroy(gameObject);
        }
    }

    // Coroutine to destroy the projectile after a set delay
    private IEnumerator DestroyAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
