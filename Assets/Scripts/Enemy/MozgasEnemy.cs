using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MozgasEnemy : Mozgas
{
    [SerializeField] private float stopDistance;
    [SerializeField] private float randomRange = 8;

    private Transform playerTransform;
    private Vector3 offset;

    private float distance;
    private bool flip = false;

    protected override void doOnStart()
    {
        base.doOnStart();

        playerTransform = GameObject.Find("Player").transform;

        offset = new Vector3(Random.Range(-randomRange, randomRange), Random.Range(-8, 8), 0);
    }

    private void FixedUpdate()
    {
        moveToPlayer();
        flipCheck();
    }

    private void moveToPlayer()
    {
        if (stop())
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position + offset, Time.deltaTime * speed);
        }

        distance = transform.position.x - playerTransform.position.x;
    }

    private bool stop()
    {
        if (Vector2.Distance(transform.position, playerTransform.position) < stopDistance) return false;
        else return true;
    }

    private void flipCheck()
    {
        if (!flip && distance > 0) flipEnemy();
        else if (flip && distance < 0) flipEnemy();
    }

    private void flipEnemy()
    {
        flip = !flip;

        transform.Rotate(0f, 180f, 0f);
    }
}
