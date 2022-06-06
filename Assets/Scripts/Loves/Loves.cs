using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loves : MonoBehaviour
{
    [SerializeField] protected GameObject lovedek;

    private Transform shootPoint;
    private Gun stats;

    protected float cooldown;
    protected float CD = 1;

    private void Start()
    {
        shootPoint = transform.Find("AimPoint");
    }

    protected void shooting(Quaternion dir)
    {
        if (cooldown <= Time.time)
        {
            for (int i = 0; i <= stats.BulletCount; i++)
            {
                GameObject bullet = Instantiate(lovedek, shootPoint.position, dir);
                bullet.GetComponent<Bullet>().setStats(shootPoint, stats.Damage, stats.Velocity, getSpread());
                cooldown = Time.time + CD;
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
    }
}
