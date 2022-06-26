using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    private static bool pickedUp = false;

    private void Start()
    {
        if (pickedUp)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        pickedUp = true;
    }
}
