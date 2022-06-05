using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGun : MonoBehaviour
{
    [SerializeField] private List<GameObject> Guns;
    private GameObject activeGun;
    private void Start()
    {
        SetGun(0);
    }
    public void SetGun(int n)
    {
        if (transform.childCount != 0)
        {
            Destroy(activeGun);
        }

        activeGun = Guns[n];
        Instantiate(activeGun, transform);
    }
}
