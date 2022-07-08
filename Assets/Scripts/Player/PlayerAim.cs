using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Transform armRotation;
    private Vector3 mousePos;
    private float mouseZAngle;
    private bool flip = true;

    private void Start()
    {
        armRotation = transform.Find("rotation");
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
        

        if (Mathf.Abs(mouseZAngle) < 85 && flip == false)
        {
            flipPlayer();
        }
        else if (Mathf.Abs(mouseZAngle) > 95 && flip == true)
        {
            flipPlayer();
        }
    }

    private void direction()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mouseZAngle = Mathf.Atan2(mousePos.y, mousePos.x);
        mouseZAngle = Mathf.Rad2Deg * mouseZAngle;

        armRotation.eulerAngles = new Vector3(0, 0, mouseZAngle);
    }

    private void flipPlayer()
    {
        flip = !flip;

        transform.Rotate(0f, 180f, 0f);
        armRotation.localScale = new Vector3(armRotation.localScale.x, armRotation.localScale.y * -1, armRotation.localScale.z);
    }
}
