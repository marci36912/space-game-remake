using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet
{
    protected override void doOnTrigger(Collider2D collision)
    {
        if (collision.tag == "wall") Destroy(gameObject);
        if (MozgasPlayer.damageable) return;
        var tmp = collision.GetComponent<PlayerHealth>();
        if (tmp == null) return;

        tmp.getDamage(Damage);
        Destroy(gameObject);
    }
}
