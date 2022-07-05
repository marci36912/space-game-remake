using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : Health, IHpManager
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private int MaxHealth;

    private void Start()
    {
        SetHealth = MaxHealth;
        healthBar.maxValue = MaxHealth;
        healthBar.value = SetHealth;
    }

    public override void getDamage(int n)
    {
        base.getDamage(n);
        healthBar.value = SetHealth;
    }
}
