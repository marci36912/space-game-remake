using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    private float cooldown = 0;
    private float cooldownTime = 8;
    
    private void FixedUpdate()
    {
        if (cooldown <= Time.time)
        {
            shoot();
        }
    }

    private void shoot()
    {
        GameObject bulletTMP = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletTMP.GetComponent<BulletEnemy>().setStats(transform, 20, 7, 0);

        cooldown = Time.time + cooldownTime;
    }
}
