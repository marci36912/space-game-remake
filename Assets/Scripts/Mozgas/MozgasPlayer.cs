using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MozgasPlayer : Mozgas
{
    private float horizontalis;
    private float vertikalis;
    private void Update()
    {
        horizontalis = Input.GetAxisRaw("Horizontal");
        vertikalis = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        entity.velocity = (new Vector2(horizontalis, vertikalis) * speed);
    }
}
