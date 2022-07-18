using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sword : MonoBehaviour
{
    private static float cooldown = 0;

    private TextMeshProUGUI bulletText;
    private Animator anim;
    private Transform hitReg;
    private float cooldownTime = 1;
    private int hit = 0;
    private int damage = 50;
    private bool mouseDown;
    
    private void Start()
    {
        bulletText = GameObject.Find("bulletText").GetComponent<TextMeshProUGUI>();
        anim = FindObjectOfType<Animator>();
        hitReg = transform.parent;
        damage = (int)(damage * Buffs.SwordDamage);
        PlayerHealth.OnPlayerDeath += onDeath;
    }

    private void OnEnable() 
    {
        if(bulletText != null) bulletText.text = "";
    }
    #region playerdeath
    private void OnDestroy()
    {
        PlayerHealth.OnPlayerDeath -= onDeath;
    }

    private void onDeath()
    {
        enabled = false;
        Destroy(gameObject);
    }
    #endregion

    private void Update()
    {
        mouseDown = Input.GetKey(KeyCode.Mouse0);
    }

    private void FixedUpdate()
    {
        if (mouseDown && onCooldown())
        {
            mouseDown = false;
            hitAnimation();
            collisionDetect();
            cooldown = cooldownTime + Time.time;
            AudioManager.Instance.PlayEffect(SoundIds.PlayerHurt);
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

    private void hitAnimation()
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
        return cooldown <= Time.time;
    }
}
