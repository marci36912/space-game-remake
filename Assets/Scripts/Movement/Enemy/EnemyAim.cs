using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    private GameObject playerTransform;
    private Vector3 rotationVector;

    private void Start()
    {
        rotationVector = new Vector3(0,0,0);
        playerTransform = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        rotationVector.z = rotation();
        transform.eulerAngles = rotationVector;
    }

    private float rotation()
    {
        Vector3 tmp = playerTransform.transform.position - transform.position;
        return (Mathf.Atan2(tmp.y, tmp.x) * Mathf.Rad2Deg);
    }
}
