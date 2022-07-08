using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int SetHealth { protected set; get; }
    [SerializeField] protected GameObject particles;

    private void Update()
    {
        if (SetHealth <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        if(particles != null) Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public virtual void getDamage(int n)
    {
        SetHealth -= n;
    }
}
