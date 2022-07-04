using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelBetween : VelBuff
{
    private void OnDestroy()
    {
        WaveSystem.Instance.pickedUpBuff();
        BuffBetweenRounds.Instance.resetBuff();
    }
}
