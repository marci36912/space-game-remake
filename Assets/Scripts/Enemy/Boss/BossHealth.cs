using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : Health, IHpManager
{
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
        if (SetHealth / MaxHealth >= 0.5 && !secondStage)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = stages[0];
            secondStage = true;
            shield.SetActive(true);
        }
        else if (SetHealth / MaxHealth >= 0.15 && !thirdStage)
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
            Instantiate(particles, transform.position, Quaternion.identity);
            Wallet.Instance.addAmmount(1000);
            Destroy(gameObject);
        }
    }
}
