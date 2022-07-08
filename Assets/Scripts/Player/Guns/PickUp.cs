using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{
    [SerializeField] private int n;
    [SerializeField] private int price;
    [SerializeField] private string gunName;

    private TextMeshPro priceTag;
    private bool zone;
    private GameObject player;

    private void Start()
    {
        priceTag = transform.GetChild(0).GetComponent<TextMeshPro>();
        priceTag.text = $"{gunName} \n {price} gold";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            zone = true;
            player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            zone = false;
        }
    }

    private void LateUpdate()
    {
        if (zone)
        {
            pickUp();
        }
    }

    private void pickUp()
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
