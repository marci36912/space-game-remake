using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MozgasEnemy : Mozgas
{
    [SerializeField] private float stopDistance;
    [SerializeField] private float randomRange = 8;
    [SerializeField] private float minDistance = 2;
    [SerializeField] private bool shouldFlip;
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
        if (shouldFlip)flipCheck();
    }

    private void moveToPlayer()
    {
        if(playerDistance() <= minDistance)
        {
            entity.velocity = (transform.position - playerTransform.position).normalized * speed * 1.2f;
        }
        else if(playerDistance() > minDistance && stop())
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position + offset, Time.deltaTime * speed);
        }
        else if(playerDistance() >= minDistance)
        {
            entity.velocity = Vector3.zero;
        }

        distance = transform.position.x - playerTransform.position.x;
    }

    private float playerDistance()
    {
        return Vector2.Distance(transform.position, playerTransform.position);
    }
    private bool stop()
    {
        if (playerDistance() < stopDistance) return false;
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
