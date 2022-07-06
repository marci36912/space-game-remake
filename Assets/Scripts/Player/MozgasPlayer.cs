using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MozgasPlayer : Mozgas
{
    [SerializeField] private EnergyBar energyBar;

    public static bool damageable { get; private set; }

    private float horizontalis;
    private float vertikalis;

    private float dashCoolDown = 0;
    private float dash = 23;
    private float length = 0.3f;

    private float speedActive;

    private bool dashing = false;

    protected override void doOnStart()
    {
        base.doOnStart();

        speedActive = speed;
        PlayerHealth.OnPlayerDeath += onDeath;
    }

    private void OnDestroy()
    {
        PlayerHealth.OnPlayerDeath -= onDeath;
    }

    private void onDeath()
    {
        entity.bodyType = RigidbodyType2D.Static;
        enabled = false;
    }

    private void Update()
    {
        horizontalis = Input.GetAxisRaw("Horizontal");
        vertikalis = Input.GetAxisRaw("Vertical");

        CheckForDash();
    }

    private void FixedUpdate()
    {
        entity.velocity = (new Vector2(horizontalis, vertikalis).normalized * speedActive);

        Dash();
    }


    private void CheckForDash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dashing = true;
        }
    }
    private void Dash()
    {
        if (dashing && dashCoolDown <= Time.time && length <= 0)
        {
            AudioManager.Instance.PlayDash();
            length = 0.2f;
            speedActive = dash;
            dashCoolDown = Time.time + 6;
            if(Shooting.Instance != null) Shooting.Instance.reload();
            energyBar.nullTheValue();
        }

        if (length > 0)
        {
            damageable = true;
            length -= Time.deltaTime;

            if (length <= 0)
            {
                speedActive = speed;
                damageable = false;
            }
        }
        dashing = false;
    }
}
