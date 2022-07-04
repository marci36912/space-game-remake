using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
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
        damage = Buffs.Damage;
        cd = Buffs.Cd;
        velocity = Buffs.Velocity;
        stats = GunStats.ReturnGun(n);
        shootPoint = transform.Find("AimPoint");
        loves = KeyCode.Mouse0;
    }
    private void Update()
    {
        active = Input.GetKey(loves);
    }

    private void FixedUpdate()
    {
        if (active)
        {
            shooting(angle().rotation);
        }
    }

    private Transform angle()
    {
        return transform.parent.gameObject.transform;
    }

    private void shooting(Quaternion dir)
    {
        if (onCooldown())
        {
            for (int i = 0; i < stats.BulletCount; i++)
            {
                GameObject bullet = Instantiate(lovedek, shootPoint.position, dir);
                bullet.GetComponent<Bullet>().setStats(shootPoint, (int)((float)stats.Damage * damage), (int)((float)stats.Velocity * velocity), getSpread());
                cooldown = Time.time + (stats.Cooldown + cd);
            }
        }
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
