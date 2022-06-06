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
