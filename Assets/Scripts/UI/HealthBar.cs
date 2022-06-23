using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;

    private Slider healthSlider;

    private void Start()
    {
        healthSlider = GetComponent<Slider>();
        healthSlider.maxValue = playerHealth.getMaxHealth();
    }

    private void FixedUpdate()
    {
        healthSlider.value = playerHealth.getCurrentHealth();
    }
}
