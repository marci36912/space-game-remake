using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas hud;
    [SerializeField] private Canvas background;
    [SerializeField] private Slider[] sliders;
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
                sliderMaanger();
            }
            else
            {
                pauseHud.enabled = true;
                background.enabled = true;
                hud.enabled = false;
                Time.timeScale = 0;
                sliderMaanger();
            }
        }
    }

    private void sliderMaanger()
    {
        if (sliders[0].interactable)
        {
            foreach (var item in sliders)
            {
                item.interactable = false;
            }
        }
        else
        {
            foreach (var item in sliders)
            {
                item.interactable = true;
            }
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
