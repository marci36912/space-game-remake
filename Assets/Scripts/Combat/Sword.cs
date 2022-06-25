using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Animator anim;
    private Transform hitReg;

    private int hit = 0;

    private bool mouseDown;

    private int damage = 50;

    private float cooldown = 1;
    private static float time = 0;

    private void Start()
    {
        anim = FindObjectOfType<Animator>();
        hitReg = transform.parent;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            mouseDown = true;
        }
    }

    private void FixedUpdate()
    {
        if (mouseDown && onCooldown())
        {
            hitManager();
            collisionDetect();
            time = cooldown + Time.time;
            mouseDown = false;
        }
    }

    private void collisionDetect()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(hitRegVector(), 2);

        if (hits.Length == 0) return;

        foreach (var item in hits)
        {
            var tmp = item.GetComponent<IHpManager>();
            if (tmp == null) continue;

            tmp.getDamage(damage);
        }
    }

    private Vector2 hitRegVector()
    {
        return new Vector2(hitReg.transform.position.x, hitReg.transform.position.y);
    }

    private void hitManager()
    {
        if (hit == 0)
        {
            hit = 1;
            anim.Play("sword_swing");
        }
        else
        {
            hit = 0;
            anim.Play("sword_swing_back");
        }
    }

    public static bool onCooldown()
    {
        return time <= Time.time;
    }
}
