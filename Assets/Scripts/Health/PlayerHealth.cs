using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    private int maxHealth;
    private void Start()
    {
        maxHealth = 100 + Buffs.Hp;
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
