using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health, IHpManager
{
    private void Start()
    {
        SetHealth = 100;
    }

    public override void Death()
    {
        if (SetHealth <= 0)
        {
            //TODO particle system, enemy death.

            Debug.Log("Deadxd");
            //Debug.Log("Overwrite");
        }
    }
}
