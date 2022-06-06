using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MozgasEnemy : Mozgas, IEnemyZone
{
    [SerializeField] float findRadius = 4;

    private GameObject playerTransform;
    private LayerMask playerMask;

    private void Start()
    {
        playerMask = LayerMask.GetMask("Player");
        playerTransform = GameObject.Find("Player");

        //Debug.Log(playerTransform.transform.name);
    }

    private void FixedUpdate()
    {
        mozgas();
    }

    private void mozgas()
    {
        if (playerZone() && tooNear())
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.transform.position, Time.deltaTime * speed);
            transform.eulerAngles = new Vector3(0, 0, rota());
        }
    }

    private float rota()
    {
        Vector3 tmp = playerTransform.transform.position - transform.position;
        return (Mathf.Atan2(tmp.y, tmp.x) * Mathf.Rad2Deg);
    }

    private bool tooNear()
    {
        if (Vector2.Distance(transform.position, playerTransform.transform.position) < 3) return false;
        else return true;
    }
    public bool playerZone()
    {
        return Physics2D.OverlapCircle(transform.position, findRadius, playerMask);
    }
}
