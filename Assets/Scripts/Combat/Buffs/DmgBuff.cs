using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgBuff : BuffPickup
{
    protected override void buff()
    {
        base.buff();
        Buffs.Instance.DamageBuff();
    }
}
