using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    public static Shooting Instance;

    [SerializeField] private GameObject bulletObject;
    [SerializeField] private Guns n;

    private TextMeshProUGUI bulletText;
    private Transform aimPoint; //where the bullets come from
    private Transform gunPoint; //the arm that holds the gun
    private Gun stats;
    private int magazine;
    private static float cooldown = 0;
    private bool isShooting;

    private void Start()
    {
        Instance = this;

        bulletText = GameObject.Find("bulletText").GetComponent<TextMeshProUGUI>();
        aimPoint = transform.Find("AimPoint");
        stats = GunStats.ReturnGun(n);

        magazine = stats.Magazine;
        bulletText.text = magazineStatus();

        PlayerHealth.OnPlayerDeath += onDeath;
    }
#region playerdeath
    private void OnDestroy()
    {
        bulletText.text = "";
        PlayerHealth.OnPlayerDeath -= onDeath;
    }

    private void onDeath()
    {
        enabled = false;
    }
    #endregion
    private void Update()
    {
        isShooting = Input.GetKey(KeyCode.Mouse0);
        reloading();
    }

    private void FixedUpdate()
    {
        if (isShooting) shooting();
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
                GameObject bullet = Instantiate(bulletObject, aimPoint.position, gunPointTransform().rotation);
                bullet.GetComponent<Bullet>().setStats(gunPointTransform(), (int)(stats.Damage * Buffs.Damage), (int)(stats.Velocity * Buffs.Velocity), getRandomSpread());
                cooldown = Time.time + 0.6f;
            }
            magazine--;
            bulletText.text = magazineStatus();
            AudioManager.Instance.PlayEffect(SoundIds.PlayerShoot);
        }
    }
    private Transform gunPointTransform()
    {
        return transform.parent.gameObject.transform;
    }
    private string magazineStatus()
    {
        return magazine + "/" + stats.Magazine;
    }
    private bool isEmpty()
    {
        return magazine == 0;
    }
    private float getRandomSpread()
    {
        return Random.Range(-stats.Spread, stats.Spread + 1);
    }

    public void reload()
    {
        magazine = stats.Magazine;
        bulletText.text = magazineStatus();
    }
    public static bool onCooldown()
    {
        return cooldown <= Time.time;
    }
}
