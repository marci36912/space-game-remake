using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBetween : SwordBuff
{
    private void OnDestroy()
    {
        WaveSystem.Instance.pickedUpBuff();
        BuffBetweenRounds.Instance.resetBuff();
    }
}
