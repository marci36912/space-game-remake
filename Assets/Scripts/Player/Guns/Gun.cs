using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun
{
    public string Name { private set; get; }
    public int Damage { private set; get; }
    public int Velocity { private set; get; }
    public float Spread { private set; get; }
    public int BulletCount { private set; get; }
    public float Cooldown { private set; get; }

    public Gun(string name, int damage, int velocity, float spread, int bulletCount, float cooldown)
    {
        Name = name;
        Damage = damage;
        Velocity = velocity;
        Spread = spread;
        BulletCount = bulletCount;
        Cooldown = cooldown;
    }
}
