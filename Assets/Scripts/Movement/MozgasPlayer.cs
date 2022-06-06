using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MozgasPlayer : Mozgas
{
    private float horizontalis;
    private float vertikalis;

    private float dashCoolDown = 0;
    private float dash = 23;
    private float length = 0.3f;

    private float speedActive;

    private bool dashing = false;


    private void Start()
    {
        entity = GetComponent<Rigidbody2D>();
        speedActive = speed;
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
            dashCoolDown = Time.time + 3;
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
