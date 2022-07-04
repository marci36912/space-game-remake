using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private float cooldownTime, damage, velocity, spread, bulletCount;

    private float cooldown;

    private void Start()
    {
        cooldown = Random.Range(2, 10);
    }

    private void FixedUpdate()
    {
        if (cooldown <= Time.time)
        {
            shoot();
        }
    }

    private void shoot()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bulletTMP = Instantiate(bullet, transform.position, Quaternion.identity);
            bulletTMP.GetComponent<BulletEnemy>().setStats(transform, (int)damage, (int)velocity, getSpread());
        }

        cooldown = Time.time + cooldownTime;
    }

    private float getSpread()
    {
        return Random.Range(-spread, spread + 0.2f);
    }
}
