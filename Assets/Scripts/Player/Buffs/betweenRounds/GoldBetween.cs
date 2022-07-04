using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBetween : MoneyBuff
{
    private void OnDestroy()
    {
        WaveSystem.Instance.pickedUpBuff();
        BuffBetweenRounds.Instance.resetBuff();
    }
}
