using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private int n;

    private bool zone;
    private GameObject player;
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
        if (Input.GetKey(KeyCode.E))
        {
            player.GetComponentInChildren<GetGun>().SetGun(n);
            Destroy(gameObject);
            return;
        }
    }
}
