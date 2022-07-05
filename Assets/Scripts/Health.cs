using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int SetHealth { protected set; get; }
    [SerializeField] protected GameObject particles;

    private void Update()
    {
        Death();
    }

    public virtual void Death()
    {
        
    }
    public virtual void getDamage(int n)
    {
        SetHealth -= n;
    }
}
