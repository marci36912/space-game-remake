using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBuff : BuffPickup
{
    protected override void buff()
    {
        base.buff();
        Buffs.Instance.GoldBuff();
    }
}
