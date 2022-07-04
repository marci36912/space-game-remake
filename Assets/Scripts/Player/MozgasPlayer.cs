using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MozgasPlayer : Mozgas
{
    [SerializeField] private EnergyBar energyBar;

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
            length = 0.3f;
            speedActive = dash;
            dashCoolDown = Time.time + 4;
            if(Shooting.Instance != null) Shooting.Instance.reload();
            energyBar.nullTheValue();
        }

        if (length > 0)
        {
            length -= Time.deltaTime;

            if (length <= 0)
            {
                speedActive = speed;
            }
        }
        dashing = false;
    }
}
