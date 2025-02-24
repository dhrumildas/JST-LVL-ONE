using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthRestored = 5;
    AudioSource pickupSource;
    public Vector3 spin = new Vector3(0, 180, 0);
    private void Awake()
    {
        pickupSource = GetComponent<AudioSource>();
    }
    
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();

        if (damageable)
        {
            bool wasHealed = damageable.Heal(healthRestored);
            if(wasHealed)
            {
                if(pickupSource)
                    AudioSource.PlayClipAtPoint(pickupSource.clip,gameObject.transform.position,pickupSource.volume);
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        transform.eulerAngles += spin * Time.deltaTime;
    }
}
