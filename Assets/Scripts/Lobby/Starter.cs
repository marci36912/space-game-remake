using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour
{
    public static bool pickedUp;

    private void Start()
    {
        if (pickedUp)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if(SceneManager.GetActiveScene().name == "LobbyScene")pickedUp = true;
    }
}
