using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CdBuff : BuffPickup
{
    protected override void buff()
    {
        base.buff();
        Buffs.Instance.CdReduction();
    }
}
