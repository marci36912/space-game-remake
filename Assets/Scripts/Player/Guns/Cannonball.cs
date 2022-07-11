using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : Bullet
{
    [SerializeField] private ParticleSystem explosion;
    private bool playedExplosion = false;
    protected override void doOnTrigger(Collider2D collision)
    {
        if (collision.name == "shield" || collision.tag == "wall") Destroy(gameObject);

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 2);

        if (hits.Length == 0) return;

        foreach (var item in hits)
        {
            var tmp = item.GetComponent<IHpManager>();
            if (tmp == null) continue;

            tmp.getDamage(Damage);
            playExplosionOnce();
        }
    }

    private void playExplosionOnce()
    {
        if(!playedExplosion && explosion != null)
        { 
            Instantiate(explosion, transform.position, Quaternion.identity);
            playedExplosion = true;
        }
    }
}
