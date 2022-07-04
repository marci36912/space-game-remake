using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mozgas : MonoBehaviour             //rigidbody movement
{
    protected Rigidbody2D entity;
    [SerializeField] protected int speed = 5;
    void Start()
    {
        doOnStart();
    }

    protected virtual void doOnStart()
    {
        entity = GetComponent<Rigidbody2D>();
    }
}
