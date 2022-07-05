using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Mozgas
{
    protected Transform tr;
    protected int Damage;
    protected float Spread;

    protected override void doOnStart()
    {
        base.doOnStart();

        transform.rotation = Quaternion.Euler(0, 0, tr.rotation.eulerAngles.z + Spread);
        entity.velocity = (transform.right) * speed;

        Destroy(gameObject, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        doOnTrigger(collision);
    }

    protected virtual void doOnTrigger(Collider2D collision)
    {
        if (collision.name == "shield" || collision.tag == "wall") Destroy(gameObject);
        var tmp = collision.GetComponent<IHpManager>();
        if (tmp == null) return;

        tmp.getDamage(Damage);
        Destroy(gameObject);
    }

    public void setStats(Transform tr, int dmg, int velo, float spread)
    {
        this.tr = tr;
        Damage = dmg;
        speed = velo;
        Spread = spread;
    }
}
