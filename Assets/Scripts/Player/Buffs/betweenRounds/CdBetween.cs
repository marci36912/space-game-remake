using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CdBetween : CdBuff
{
    private void OnDestroy()
    {
        WaveSystem.Instance.pickedUpBuff();
        BuffBetweenRounds.Instance.resetBuff();
    }
}
