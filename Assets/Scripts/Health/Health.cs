using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHpManager
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
    public void getDamage(int n)
    {
        SetHealth -= n;
    }
}
