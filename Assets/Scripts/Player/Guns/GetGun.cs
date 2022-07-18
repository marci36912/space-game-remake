using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGun : MonoBehaviour
{
    [SerializeField] private List<GameObject> Guns;
    private Inventory inventory;

    private void Start()
    {
        inventory = GetComponentInParent<Inventory>();
    }
    public void SetGun(int n)
    {
        inventory.setSelected(Guns[n]);
    }
}
