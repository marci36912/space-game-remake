using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Image[] selectedPics;

    private GameObject[] guns = new GameObject[2];
    private int selected = 0;

    private int tmp = 0;

    void Update()
    {
        selectSlot();
        selectedColor();
        selectedGun();
    }

    private void selectedGun()
    {
        if (tmp == selected) return;
        else
        {
            //fegyvervaltas
            Debug.Log("fasz");
            tmp = selected;
        }
    }
    private void selectSlot()
    {
        selected += (int)Input.mouseScrollDelta.y;

        if (selected > guns.Length - 1)
        {
            selected = 0;
        }

        if (selected < 0)
        {
            selected = guns.Length - 1;
        }
    }
    private void selectedColor()
    {
        for (int i = 0; i < selectedPics.Length; i++)
        {
            if (i == selected) selectedPics[i].color = Color.white;
            else selectedPics[i].color = Color.gray;
        }
    }
}
