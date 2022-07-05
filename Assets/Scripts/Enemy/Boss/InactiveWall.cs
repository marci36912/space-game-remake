using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveWall : MonoBehaviour   
{
    [SerializeField] private GameObject boss;
    void Start()
    {
        EnterRoom.Entered += wallChange;
    }
    private void OnDestroy()
    {
        EnterRoom.Entered -= wallChange;
    }
    private void wallChange()   
    {
        transform.Find("wallBOTTON").gameObject.SetActive(true);
        boss.SetActive(true);
    }
}
