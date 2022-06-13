using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGun : MonoBehaviour
{
    [SerializeField] private List<GameObject> Guns;
    private GameObject activeGun;
    private Inventory inventory;

    private void Start()
    {
        inventory = GetComponentInParent<Inventory>();
    }
    public void SetGun(int n)
    {
        if (transform.childCount != 0)
        {
            Destroy(activeGun);
        }

        activeGun = Instantiate(Guns[n], transform);
        inventory.setSelected(Guns[n], activeGun, GunStats.ReturnGun(n));
        activeGun.GetComponent<Shooting>().setStats(GunStats.ReturnGun(n));
    }
}
