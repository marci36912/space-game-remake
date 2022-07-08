using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : Health, IHpManager
{
    public delegate void destroyFlyes();
    public static event destroyFlyes destroyThem;

    [SerializeField] private GameObject lobbyTeleport;
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
        if (healthPercentage(0.5f) && !secondStage)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = stages[0];
            secondStage = true;
            shield.SetActive(true);
        }
        else if (healthPercentage(0.15f) && !thirdStage)
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

    private bool healthPercentage(float n)
    {
        return (healthBar.value / healthBar.maxValue) <= n;
    }

    public override void getDamage(int n)
    {
        base.getDamage(n);
        healthBar.value = SetHealth;
        stageCheck();
    }

    public override void Death()
    {
        lobbyTeleport.SetActive(true);
        AudioManager.Instance.PlayEffect(SoundIds.RobotExplosion);
        Wallet.Instance.addMoney(1000);
        if(destroyThem != null) destroyThem();
        base.Death();
    }
}
