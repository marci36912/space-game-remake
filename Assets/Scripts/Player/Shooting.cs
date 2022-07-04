using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public static Shooting Instance;

    [SerializeField] protected GameObject lovedek;
    [SerializeField] private int n;

    private KeyCode loves;

    private bool active;

    private Transform shootPoint;
    private Gun stats;

    private float damage, cd, velocity;

    private static float cooldown = 0;

    private void Start()
    {
        Instance = this;

        damage = Buffs.Damage;
        cd = Buffs.Cd;
        velocity = Buffs.Velocity;
        stats = GunStats.ReturnGun(n);
        shootPoint = transform.Find("AimPoint");
        loves = KeyCode.Mouse0;

        PlayerHealth.OnPlayerDeath += onDeath;
    }

    private void OnDestroy()
    {
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
        if (active)
        {
            shooting();
        }
    }

    private Transform angle()
    {
        return transform.parent.gameObject.transform;
    }

    private void shooting()
    {
        if (onCooldown())
        {
            for (int i = 0; i < stats.BulletCount; i++)
            {
                GameObject bullet = Instantiate(lovedek, shootPoint.position, angle().rotation);
                bullet.GetComponent<Bullet>().setStats(angle(), (int)((float)stats.Damage * damage), (int)((float)stats.Velocity * velocity), getSpread());
                cooldown = Time.time + (stats.Cooldown + cd);
            }
        }
    }

    public void reload()
    {
        cooldown = 0;
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
