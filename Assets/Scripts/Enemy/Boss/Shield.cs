using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private float speed = 15;
    private float zRotation = 0;
    private bool clockwise = true;

    private void Update()
    {
        if (clockwise)
        {
            zRotation += Time.deltaTime * speed;
        }
        else
        {
            zRotation -= Time.deltaTime * speed;
        }

        transform.rotation = Quaternion.Euler(0, 0, zRotation);

        if (zRotation >= 380)
        {
            clockwise = !clockwise;
        }
        else if(zRotation <= -20)
        {
            clockwise = !clockwise;
        }
    }
}
