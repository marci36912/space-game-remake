using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IEnemyZone
{
    bool playerZone();
}

interface IHpManager
{
    int SetHealth { get; }
    void getDamage(int dmg);
    void Death();
}
