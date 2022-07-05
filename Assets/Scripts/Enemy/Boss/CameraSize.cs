using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    [SerializeField] private Vector2 min, max;

    private void Start()
    {
        EnterRoom.Entered += cameraSizeChange;
    }
    private void OnDestroy()
    {
        EnterRoom.Entered -= cameraSizeChange;
    }
    private void cameraSizeChange()
    {
        gameObject.GetComponent<CameraFollow>().setMinMax(min, max);
        Camera.main.orthographicSize = 13;
    }
}
