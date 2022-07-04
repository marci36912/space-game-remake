using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet
{
    protected override void doOnTrigger(Collider2D collision)
    {
        var tmp = collision.GetComponent<PlayerHealth>();
        if (tmp == null) return;

        tmp.getDamage(Damage);
        Destroy(gameObject);
    }
}
