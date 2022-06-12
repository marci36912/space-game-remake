using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] protected GameObject lovedek;

    private KeyCode loves;

    private bool active;

    private Transform shootPoint;
    private Gun stats;

    private float cooldown = 0;

    private void Update()
    {
        if (Input.GetKeyDown(loves))
        {
            active = true;
        }
    }

    private void FixedUpdate()
    {
        if (active)
        {
            shooting(angle().rotation);
            active = false;
        }
    }

    private Transform angle()
    {
        return transform.parent.gameObject.transform;
    }

    private void shooting(Quaternion dir)
    {
        if (cooldown <= Time.time)
        {
            for (int i = 0; i < stats.BulletCount; i++)
            {
                GameObject bullet = Instantiate(lovedek, shootPoint.position, dir);
                bullet.GetComponent<Bullet>().setStats(shootPoint, stats.Damage, stats.Velocity, getSpread());
                cooldown = Time.time + stats.Cooldown;
            }
        }
    }

    private float getSpread()
    {
        return Random.Range(-stats.Spread, stats.Spread + 0.1f);
    }

    public void setStats(Gun gun)
    {
        stats = gun;
        shootPoint = transform.Find("AimPoint");
        loves = KeyCode.Mouse0;
    }
}
