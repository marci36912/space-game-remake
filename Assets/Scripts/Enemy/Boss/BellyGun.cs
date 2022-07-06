using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellyGun : MonoBehaviour
{
    [SerializeField] private GameObject bellyGun;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            bellyGun.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            bellyGun.SetActive(false);
        }
    }
}
