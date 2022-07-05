using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private float speed = 15;
    private float rotation = 0;
    private bool clockwise = true;

    private void Update()
    {
        if (clockwise)
        {
            rotation += Time.deltaTime * speed;
        }
        else
        {
            rotation -= Time.deltaTime * speed;
        }

        transform.rotation = Quaternion.Euler(0, 0, rotation);

        if (rotation >= 380)
        {
            clockwise = !clockwise;
        }
        else if(rotation <= -20)
        {
            clockwise = !clockwise;
        }
    }
}
