using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Animator anim;
    private Transform hitReg;

    private int hit = 0;

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
            hitManager();
            mouseDown = false;

            Debug.Log("hit");
        }
    }

    private void hitManager()
    {
        if (hit == 0)
        {
            hit = 1;
            anim.Play("sword_swing");
        }
        else
        {
            hit = 0;
            anim.Play("sword_swing_back");
        }
    }
}
