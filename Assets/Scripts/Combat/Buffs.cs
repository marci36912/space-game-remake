using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    public static Buffs Instance;

    public static int Hp { private set; get; } = 0;
    public static float Gold { private set; get; } = 1;     
    public static float Damage { private set; get; } = 1;   
    public static float Cd { private set; get; } = 0;       
    public static float Velocity { private set; get; } = 1; 
    public static float SwordDamage { private set; get; } = 1;


    private void Start()
    {
        if (Instance == null)
        {
            Instance = GetComponent<Buffs>();
        }
    }

    public void HpBuff()
    {
        Hp += 10;
    }

    public void GoldBuff()
    {
        Gold += 0.2f;
    }

    public void DamageBuff()
    {
        Damage += 0.2f;
    }

    public void CdReduction()
    {
        Cd -= 0.2f;
    }

    public void VelocityBuff()
    {
        Velocity += 0.2f;
    }

    public void SwordBuff()
    {
        SwordDamage += 0.3f;
    }
}
