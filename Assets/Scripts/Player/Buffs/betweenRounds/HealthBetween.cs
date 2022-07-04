using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBetween : HealthBuff
{
    private void OnDestroy()
    {
        WaveSystem.Instance.pickedUpBuff();
        BuffBetweenRounds.Instance.resetBuff();
    }
}
