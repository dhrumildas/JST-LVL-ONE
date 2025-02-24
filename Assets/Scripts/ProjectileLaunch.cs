using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    public Transform launchpoint;
    public GameObject projectile;

    public void FireProjectile()
    {
        GameObject arrow =  Instantiate(projectile, transform.position, projectile.transform.rotation);
        Vector3 scale = arrow.transform.localScale;

        //Flips the damn arrow towards player's direction
        arrow.transform.localScale = new Vector3(
            scale.x * transform.localScale.x > 0 ? 1 : -1,
            scale.y,
            scale.z);
    }
}
