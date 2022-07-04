using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Transform aimPoint;

    private Vector3 mousePos;
    private float angle;

    private bool flip = true;

    private void Start()
    {
        aimPoint = transform.Find("rotation");
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
    private void FixedUpdate()
    {
        direction();
        

        if (Mathf.Abs(angle) < 85 && flip == false)
        {
            flipPlayer();
        }
        else if (Mathf.Abs(angle) > 95 && flip == true)
        {
            flipPlayer();
        }
    }

    private void direction()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(mousePos.y, mousePos.x);
        angle = Mathf.Rad2Deg * angle;

        aimPoint.eulerAngles = new Vector3(0, 0, angle);
    }

    private void flipPlayer()
    {
        flip = !flip;

        transform.Rotate(0f, 180f, 0f);
        aimPoint.localScale = new Vector3(aimPoint.localScale.x, aimPoint.localScale.y * -1, aimPoint.localScale.z);
    }
}
