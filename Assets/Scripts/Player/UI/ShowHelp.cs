using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowHelp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI helpText;
    private string[] helps = 
    {" W\nASD - Mozgas\n\nE - Vasarlas\n\nBal egergomb - loves\n\nSpace - dash",
    "Ket slot van fegyverre\nVagy a gorgovel lehet valtani\nVagy pedig az 1-es \nvagy a 2-es gombbal",
    "Dash kozben nem lehet sebzodni\nIlletve azonnal ujratoltunk",
    "Minden megolt enemy utan a boltban elkoltheto penzt kapunk\nMindig 5 kor van, a vegen vagy a lobbyba mehetunk vissza vasarolni, vagy a bosshoz mehetunk",
    "Lehetosegunk van fegyvereket\nIlletve buffokat venni;",
    "Fegyver sebzest, ujratoltesi idot\nLovedek repulesi sebesseget (velocity)\nPlussz eletet, penz szorzot\nEs kard sebzest lehet fejleszteni",
    "A jatekban az \n\nEsc\n\nMegnyomavasaval lehet megnezni az aktualis buffokat",
    "Casual mode eseten 100 extra elettel\nEs 1000 golddal kezdunk"};
    private int n;

    private void Start() {
        helpText.text = helps[0];
        n = 0;
    }

    public void nextHelp()
    {
        n++;
        if(n >= helps.Length) n = 0;
        helpText.text = helps[n];
    }

    public void prevHelp()
    {
        n--;
        if(n < 0) n = helps.Length - 1;
        helpText.text = helps[n];
    }
}
