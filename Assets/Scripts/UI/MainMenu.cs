using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Canvas easy;
    private void Start()
    {
        Buffs.Instance.nullBuffs();
        Wallet.Instance.nullMoney();
        Starter.pickedUp = false;
    }

    public void showHelp(bool help)
    {
        easy.enabled = help;
    }

    public void easyMode(bool easy)
    {
        if (easy)
        {
            for (int i = 0; i < 10; i++)
            {
                Buffs.Instance.HpBuff();
            }
            Wallet.Instance.addAmmount(1000);
        }
        else
        {
            Buffs.Instance.nullBuffs();
            Wallet.Instance.nullMoney();
            Starter.pickedUp = false;
        }
    }

    public void playGame()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
