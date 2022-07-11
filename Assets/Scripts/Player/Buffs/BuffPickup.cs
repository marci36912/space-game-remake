using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuffPickup : PickUp
{
    protected override void pickUp()
    {
        if (Input.GetKey(KeyCode.E) && Wallet.Instance.Buy(price))
        {
            buff();
            AudioManager.Instance.PlayEffect(SoundIds.PickUp);
            Destroy(gameObject);
            return;
        }
    }

    protected virtual void buff()
    {

    }
}
