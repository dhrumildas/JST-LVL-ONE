using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text healthText;
    Damageable damageable;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player == null)
        {
            Debug.Log("No player found");
        }
        damageable = player.GetComponent<Damageable>();
    }
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = CalculateSliderPercentage(damageable.Health, damageable.MaxHealth);
        healthText.text = "HP" + damageable.Health + " / " +damageable.MaxHealth;
    }

    private float CalculateSliderPercentage(float current, float maxHealth)
    {
        return current/maxHealth;
    }

    private void OnPlayerHealthChanged(int health, int maxHealth)
    {
        healthSlider.value = CalculateSliderPercentage(health, maxHealth);
        healthText.text = "HP" + health + " / " + maxHealth;
    }

    private void OnEnable()
    {
        damageable.healthChanged.AddListener(OnPlayerHealthChanged);
    }

    private void OnDisable()
    {
        damageable.healthChanged.RemoveListener(OnPlayerHealthChanged);
    }

}
