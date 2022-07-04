using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    private int maxHealth;
    private bool dead = false;
    private void Start()
    {
        maxHealth = 100 + Buffs.Hp;
        SetHealth = maxHealth;
    }
    
    public override void Death()
    {
        if (SetHealth <= 0 && !dead)
        {
            base.Death();
            dead = true;
            Instantiate(particles, transform.position, Quaternion.identity);
            Invoke("backToTheMenu", 3);
        }
    }

    private void backToTheMenu()
    {
        SceneManager.LoadScene("MenuScene");
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
