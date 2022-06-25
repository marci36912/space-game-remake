using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : Health, IHpManager
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image fillArea;

    [SerializeField] private Transform healthPosition;

    private WaveSystem wave;

    private void Start()
    {
        wave = gameObject.GetComponentInParent<WaveSystem>();
        SetHealth = 100;

        healthBar.maxValue = SetHealth;
    }

    private void FixedUpdate()
    {
        healthBar.transform.position = healthPosition.position;
        healthBar.value = SetHealth;

        fillArea.color = Color.Lerp(Color.red, Color.green, healthBar.value / healthBar.maxValue);
    }

    public override void Death()
    {
        if (SetHealth <= 0)
        {
            wave.enemyDeath();
            Destroy(gameObject);
        }
    }
}
