using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private Canvas canvas;

    private void Start()
    {
        Time.timeScale = 1;
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.enabled)
            {
                canvas.enabled = false;
                Time.timeScale = 1;
            }
            else
            {
                canvas.enabled = true;
                Time.timeScale = 0;
            }
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
