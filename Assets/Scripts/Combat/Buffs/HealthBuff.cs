using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuff : BuffPickup
{
    protected override void buff()
    {
        base.buff();
        Buffs.Instance.HpBuff();
    }
}
