using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Animator anim;
    private Transform hitReg;

    private int hit = 1;

    private bool mouseDown;

    private void Start()
    {
        anim = FindObjectOfType<Animator>();
        hitReg = transform.parent;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mouseDown = true;
        }
    }

    private void FixedUpdate()
    {
        if (mouseDown)
        {
            anim.SetInteger("hit", hit);
            anim.SetBool("hitBool", mouseDown);
            hitManager();
            mouseDown = false;
            //anim.SetBool("hitBool", mouseDown);
        }
    }

    private void hitManager()
    {
        if (hit == 0)
        {
            hit = 1;
        }
        else if(hit == 1)
        {
            hit = 0;
        }
    }
}
