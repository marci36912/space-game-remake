using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LovesPlayer : Loves
{
    [SerializeField] private KeyCode loves;
    private bool active;

    private void Update()
    {
        if (Input.GetKeyDown(loves))
        {
            active = true;
        }
    }

    private void LateUpdate()
    {
        if (active)
        {
            shooting(angl().rotation);
            active = false;
        }
    }

    private Transform angl()
    {
        return transform.parent.gameObject.transform;
    }
}
