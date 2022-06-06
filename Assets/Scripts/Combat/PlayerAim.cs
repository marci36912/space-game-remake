using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Vector3 tmpEger;
    private float szog;

    private void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(0, 0, direction());
    }

    private float direction()
    {
        tmpEger = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        szog = Mathf.Atan2(tmpEger.y, tmpEger.x);

        return Mathf.Rad2Deg * szog;
    }
}
