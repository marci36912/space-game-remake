using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    public static Shooting Instance;

    [SerializeField] protected GameObject lovedek;
    [SerializeField] private int n;

    private TextMeshProUGUI bulletText;

    private KeyCode loves;

    private bool active;

    private Transform shootPoint;
    private Gun stats;
    private int magazine;

    private static float cooldown = 0;

    private void Start()
    {
        Instance = this;
        bulletText = GameObject.Find("bulletText").GetComponent<TextMeshProUGUI>();
        stats = GunStats.ReturnGun(n);
        shootPoint = transform.Find("AimPoint");
        loves = KeyCode.Mouse0;
        magazine = stats.Magazine;
        bulletText.text = magazineStatus();
        PlayerHealth.OnPlayerDeath += onDeath;
    }

    private void OnDestroy()
    {
        bulletText.text = "";
        PlayerHealth.OnPlayerDeath -= onDeath;
    }

    private void onDeath()
    {
        enabled = false;
    }
    private void Update()
    {
        active = Input.GetKey(loves);
    }

    private void FixedUpdate()
    {
        reloading();

        if (active) shooting();
    }

    private Transform angle()
    {
        return transform.parent.gameObject.transform;
    }

    private void reloading()
    {
        if (magazine != stats.Magazine && Input.GetKeyDown(KeyCode.R) && onCooldown())
        {
            magazine = stats.Magazine;
            cooldown = Time.time + Mathf.Clamp(stats.Cooldown + Buffs.Cd, 0.4f, stats.Cooldown);
            bulletText.text = magazineStatus();
        }
        else if (isEmpty() && onCooldown())
        {
            magazine = stats.Magazine;
            cooldown = Time.time + Mathf.Clamp(stats.Cooldown + Buffs.Cd, 0.4f, stats.Cooldown);
            bulletText.text = magazineStatus();
        }
    }
    private void shooting()
    {
        if (onCooldown() && !isEmpty())
        {
            for (int i = 0; i < stats.BulletCount; i++)
            {
                GameObject bullet = Instantiate(lovedek, shootPoint.position, angle().rotation);
                bullet.GetComponent<Bullet>().setStats(angle(), (int)(stats.Damage * Buffs.Damage), (int)(stats.Velocity * Buffs.Velocity), getSpread());
                cooldown = Time.time + 0.6f;
            }
            magazine--;
            bulletText.text = magazineStatus();
            AudioManager.Instance.PlayEffect(SoundIds.PlayerShoot);
        }
    }

    private string magazineStatus()
    {
        return magazine + "/" + stats.Magazine;
    }

    private bool isEmpty()
    {
        return magazine == 0;
    }

    public void reload()
    {
        magazine = stats.Magazine;
        bulletText.text = magazineStatus();
    }
    private float getSpread()
    {
        return Random.Range(-stats.Spread, stats.Spread + 0.1f);
    }

    public static bool onCooldown()
    {
        return cooldown <= Time.time;
    }
}
