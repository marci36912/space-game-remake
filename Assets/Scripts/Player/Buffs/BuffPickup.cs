using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuffPickup : MonoBehaviour
{
    [SerializeField] private int price;
    [SerializeField] private string buffName;

    private TextMeshPro text;

    private bool zone;

    private void Start()
    {
        text = GetComponentInChildren<TextMeshPro>();
        text.text = $"{buffName}\n{price} gold";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            zone = true;
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
            buff();
            Destroy(gameObject);
            return;
        }
    }

    protected virtual void buff()
    {

    }
}
