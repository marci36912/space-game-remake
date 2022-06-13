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
    }

    void Update()
    {
        selectSlot();
        selectedGun();
    }
    
    public void setSelected(GameObject gun, GameObject active, Gun stats)
    {
        guns[selected] = gun;
        guns[selected].GetComponent<Shooting>().setStats(stats);
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
            
            Debug.Log(guns[selected] == null ? "null" : guns[selected].name);

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
