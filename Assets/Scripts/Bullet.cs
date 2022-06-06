using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Mozgas
{
    private Transform tr;
    private int Damage;
    private float Spread;

    private void Start()
    {
        entity = GetComponent<Rigidbody2D>();
        entity.velocity = (tr.right + new Vector3(0, Spread)) * speed;

        Destroy(gameObject, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
