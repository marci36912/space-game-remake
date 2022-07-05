using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : Health, IHpManager
{
    public delegate void destroyFlyes();
    public static event destroyFlyes destroyThem;

    [SerializeField] private GameObject teleport;

    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject flyers;
    [SerializeField] private GameObject smoke;

    [SerializeField] private Sprite[] stages;

    [SerializeField] private Slider healthBar;
    [SerializeField] private int MaxHealth;

    private bool secondStage = false;
    private bool thirdStage = false;


    private void Start()
    {
        SetHealth = MaxHealth;
        healthBar.maxValue = MaxHealth;
        healthBar.value = SetHealth;
    }

    private void stageCheck()
    {
        if (healthPercentage(50) && !secondStage)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = stages[0];
            secondStage = true;
            shield.SetActive(true);
        }
        else if (healthPercentage(15) && !thirdStage)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = stages[1];
            thirdStage = true;
            smoke.SetActive(true);
            for (int i = 0; i < 3; i++)
            {
                Instantiate(flyers, transform.position, Quaternion.identity);
            }
        }
    }

    private bool healthPercentage(int n)
    {
        return (healthBar.value / healthBar.maxValue * 100) <= n;
    }

    public override void getDamage(int n)
    {
        base.getDamage(n);
        healthBar.value = SetHealth;
        stageCheck();
    }

    public override void Death()
    {
        if (SetHealth <= 0)
        {
            teleport.SetActive(true);
            AudioManager.Instance.PlayRobotExplosion();
            Instantiate(particles, transform.position, Quaternion.identity);
            Wallet.Instance.addAmmount(1000);
            if(destroyThem != null) destroyThem();
            Destroy(gameObject);
        }
    }
}
