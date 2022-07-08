using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wallet : MonoBehaviour
{
    public static Wallet Instance;

    [SerializeField] private TextMeshProUGUI moneyText;
    private static int AllMoney = 9999;

    private void Start()
    {
        if (Instance == null) Instance = gameObject.GetComponent<Wallet>();
        if (moneyText != null) moneyText.text = AllMoney.ToString();
    }

    public void nullMoney()
    {
        AllMoney = 0;
    }
    public void addMoney(int n)
    {
        AllMoney += (int)((float)n * Buffs.Gold);
        if (moneyText != null) moneyText.text = AllMoney.ToString();
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
