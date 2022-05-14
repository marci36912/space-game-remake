using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mozgas : MonoBehaviour
{
    protected Rigidbody2D entity;
    [SerializeField] protected int speed = 5;
    void Start()
    {
        entity = GetComponent<Rigidbody2D>();
    }
}
