using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform target;

    Vector2 startPos;

    float startZ;
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startPos;

    float zDistanceFromTarget => transform.position.z - target.transform.position.z;

    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget)/clippingPlane;

    void Start()
    {
        startPos = transform.position;
        startZ = transform.localPosition.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 newPos = startPos + camMoveSinceStart * parallaxFactor;
        transform.position = new Vector3(newPos.x,newPos.y,startZ);
    }
}
