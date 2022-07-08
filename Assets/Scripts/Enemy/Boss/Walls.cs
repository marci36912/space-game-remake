using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    private void Start()
    {
        EnterRoom.Entered += wallChange;
    }
    private void OnDestroy()
    {
        EnterRoom.Entered -= wallChange;
    }
    private void wallChange()
    {
        gameObject.SetActive(false);
    }
}
