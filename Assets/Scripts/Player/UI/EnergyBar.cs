using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    private Slider energyBar;

    private void Start()
    {
        energyBar = GetComponent<Slider>();
        energyBar.maxValue = 4;
        energyBar.value = energyBar.maxValue;
    }

    private void FixedUpdate()
    {
        if (energyBar.value != energyBar.maxValue)
        {
            energyBar.value += Time.fixedDeltaTime;
        }
    }

    public void nullTheValue()
    {
        energyBar.value = 0;
    }
}
