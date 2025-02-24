using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    public Vector3 moveSpeed = new Vector3(0,75,0);
    public float fade = 1f;
    RectTransform textTransform;
    TextMeshProUGUI textMeshPro;
    private float time = 0f;
    private Color startColor;

    private void Awake()
    {
        textTransform = GetComponent<RectTransform>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
        startColor = textMeshPro.color;
    }

    private void Update()
    {
        textTransform.position += moveSpeed * Time.deltaTime;
        time += Time.deltaTime;
        if (time < fade)
        {
            float alphaFade = startColor.a * (1 - (time / fade));
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, alphaFade);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
