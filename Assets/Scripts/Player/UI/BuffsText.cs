using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuffsText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI gold;
    [SerializeField] private TextMeshProUGUI dmg;
    [SerializeField] private TextMeshProUGUI cd;
    [SerializeField] private TextMeshProUGUI vel;
    [SerializeField] private TextMeshProUGUI sworddmg;

    private void Start()
    {
        health.text = $"+ {Buffs.Hp}";
        gold.text = $"{Buffs.Gold * 100}%";
        dmg.text = $"{Buffs.Damage * 100}%";
        cd.text = $"{Buffs.Cd} sec";
        vel.text = $"{Buffs.Velocity * 100}%";
        sworddmg.text = $"{Buffs.SwordDamage * 100}%";
    }
}
