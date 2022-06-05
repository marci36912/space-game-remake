using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private bool zone;
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
        if (Input.GetKey(KeyCode.E))
        {
            //TODO set gun active in the inventory
        }
    }
}
