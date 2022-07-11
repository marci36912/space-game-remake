using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{
    [SerializeField] protected int price;
    [SerializeField] protected string itemName;
    protected TextMeshPro priceTag;
    private bool zone;
    protected GameObject player;

    private void Start()
    {
        priceTag = transform.Find("Text").GetComponent<TextMeshPro>();
        if(priceTag != null)priceTag.text = $"{itemName} \n {price} gold";
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

    protected virtual void pickUp()
    {
        
    }
}
