using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelBuff : BuffPickup
{
    protected override void buff()
    {
        base.buff();
        Buffs.Instance.VelocityBuff();
    }
}
