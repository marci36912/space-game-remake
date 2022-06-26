using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    public static Wallet Instance;
    private static int AllMoney = 9999;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = gameObject.GetComponent<Wallet>();
        }

        moneyText.text = AllMoney.ToString();
    }

    public void addAmmount(int n)
    {
        AllMoney += (int)((float)n * Buffs.Gold);
        moneyText.text = AllMoney.ToString();
    }

    public bool Buy(int n)
    {
        if (AllMoney >= n)
        {
            AllMoney -= n;
            moneyText.text = AllMoney.ToString();
            return true;
        }

        return false;
    }
}
