using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Mozgas
{
    private Transform tr;

    private void Start()
    {
        entity = GetComponent<Rigidbody2D>();
        entity.velocity = tr.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tmp = collision.GetComponent<IHpManager>();
        Destroy(gameObject);
        if (tmp == null) return;

        tmp.getDamage(100);  
    }
    public void setTr(Transform tr)
    {
        this.tr = tr;
    }
}
