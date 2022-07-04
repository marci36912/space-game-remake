using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgBetween : DmgBuff
{
    private void OnDestroy()
    {
        WaveSystem.Instance.pickedUpBuff();
        BuffBetweenRounds.Instance.resetBuff();
    }
}
