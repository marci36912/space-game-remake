using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MozgasPlayer : Mozgas
{
    public static bool damageable { get; private set; }
    public static int DashCoolDownTime { get; private set; } = 6;

    [SerializeField] private EnergyBar energyBar;

    private float dashCoolDown = 0;
    private float dashSpeed = 23;
    private float dashLength = 0.2f;
    private float horizontal;
    private float vertical;
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
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.Space)) dashing = true;
    }

    private void FixedUpdate()
    {
        entity.velocity = (new Vector2(horizontal, vertical).normalized * speedActive);

        Dash();
    }

    private void Dash()
    {
        if (dashing && dashCoolDown <= Time.time && dashLength <= 0)
        {
            AudioManager.Instance.PlayEffect(SoundIds.Dash);
            dashLength = 0.2f;
            speedActive = dashSpeed;
            dashCoolDown = Time.time + DashCoolDownTime;
            if(Shooting.Instance != null) Shooting.Instance.reload();
            energyBar.nullTheValue();
        }

        if (dashLength > 0)
        {
            damageable = true;
            dashLength -= Time.deltaTime;

            if (dashLength <= 0)
            {
                speedActive = speed;
                damageable = false;
            }
        }
        dashing = false;
    }
}
