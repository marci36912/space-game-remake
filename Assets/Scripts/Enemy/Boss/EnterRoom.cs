using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoom : MonoBehaviour
{
    public delegate void EnterRoomDelegate();
    public static event EnterRoomDelegate Entered;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && Entered != null)
        {
            Entered();
        }
    }
}
