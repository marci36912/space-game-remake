using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loves : MonoBehaviour
{
    [SerializeField] protected GameObject lovedek;
    private Transform shootPoint;
    protected float cooldown;
    protected float CD = 1;
    private void Start()
    {
        shootPoint = transform.Find("AimPoint");
    }

    protected void shooting(Quaternion dir)
    {
        if (cooldown <= Time.time)
        {
            GameObject bullet = Instantiate(lovedek, shootPoint.position, dir);
            bullet.GetComponent<Bullet>().setTr(shootPoint);
            cooldown = Time.time + CD;
        }
    }
}
