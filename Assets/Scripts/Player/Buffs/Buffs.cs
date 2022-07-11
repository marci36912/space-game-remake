using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    public static Buffs Instance;

    public static int Hp { private set; get; }
    public static float Gold { private set; get; } = 1;
    public static float Damage { private set; get; } = 1;
    public static float Cd { private set; get; }     
    public static float Velocity { private set; get; } = 1;
    public static float SwordDamage { private set; get; } = 1;

    public void nullBuffs()
    {
        Hp = 0;
        Gold = 1;
        Damage = 1;
        Cd = 0;
        Velocity = 1;
        SwordDamage = 1;
    }
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
        Gold += 0.1f;
    }

    public void DamageBuff()
    {
        Damage += 0.05f;
    }

    public void CdReduction()
    {
        Cd -= 0.05f;
    }

    public void VelocityBuff()
    {
        Velocity += 0.05f;
    }

    public void SwordBuff()
    {
        SwordDamage += 0.1f;
    }
}
