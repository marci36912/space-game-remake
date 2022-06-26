using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    private int maxHealth = 100;
    private void Start()
    {
        maxHealth += Buffs.Hp;
        SetHealth = maxHealth;
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }

    public float getCurrentHealth()
    {
        return SetHealth;
    }
}
