using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;

    private int maxHealth;
    private bool dead = false;
    private void Awake()
    {
        maxHealth = 100 + Buffs.Hp;
        SetHealth = maxHealth;
    }

    public override void getDamage(int n)
    {
        base.getDamage(n);
        AudioManager.Instance.PlayPlayerHurt();
    }
    public override void Death()
    {
        if (SetHealth <= 0 && !dead)
        {
            base.Death();
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            dead = true;
            AudioManager.Instance.PlayPlayerExplosion();
            Instantiate(particles, transform.position, Quaternion.identity);
            Invoke("backToTheMenu", 3);
            OnPlayerDeath();
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
