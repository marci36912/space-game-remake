using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Image[] selectedPics;

    private GameObject activeGun;

    private GameObject[] guns = new GameObject[2];
    private int selected = 0;

    private int tmp = 0;

    private Transform gp;

    private void Start()
    {
        gp = transform.Find("rotation").transform.Find("GunPoint");
        selectedPics[selectedPics.Length-1].color = Color.gray;
    }

    void Update()
    {
        if (Shooting.onCooldown())
        {
            selectSlot();
            selectedGun();
        }
    }

    private void LateUpdate()
    {
        if (!Shooting.onCooldown()) selectedPics[selected].color = Color.red;
        else selectedPics[selected].color = Color.white;
    }

    public void setSelected(GameObject gun, GameObject active)
    {
        guns[selected] = gun;
        selectedPics[selected].sprite = gun.GetComponent<SpriteRenderer>().sprite;
        activeGun = active;
    }
    private void selectedGun()
    {
        if (tmp == selected) return;
        else
        { 
            tmp = selected;

            if (gp.childCount != 0) Destroy(activeGun);

            if (guns[selected] != null) activeGun = Instantiate(guns[selected], gp);
                
            selectedColor();
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
