using UnityEngine;

interface IHpManager
{
    int SetHealth { get; }
    void getDamage(int dmg);
    void Death();
}
