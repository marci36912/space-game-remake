using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : PickUp
{
    [SerializeField] private int n;
    protected override void pickUp()
    {
        if (Input.GetKey(KeyCode.E) && Wallet.Instance.Buy(price))
        {
            player.transform.Find("rotation").GetComponentInChildren<GetGun>().SetGun(n);
            AudioManager.Instance.PlayEffect(SoundIds.PickUp);
            Destroy(gameObject);
            return;
        }
    }
}
