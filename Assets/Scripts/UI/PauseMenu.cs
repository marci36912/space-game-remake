using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas hud;
    [SerializeField] private Canvas background;
    private Canvas pauseHud;

    private void Start()
    {
        Time.timeScale = 1;
        pauseHud = GetComponent<Canvas>();
        pauseHud.enabled = false;
        background.enabled = false;
        hud.enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseHud.enabled)
            {
                pauseHud.enabled = false;
                background.enabled = false;
                hud.enabled = true;
                Time.timeScale = 1;
            }
            else
            {
                pauseHud.enabled = true;
                background.enabled = true;
                hud.enabled = false;
                Time.timeScale = 0;
            }
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
