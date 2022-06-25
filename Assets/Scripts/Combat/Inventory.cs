using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private static GameObject[] guns = new GameObject[2];

    private Image[] selectedPics = new Image[2];

    private GameObject activeGun;
    
    private int selected = 0;

    private int tmp = 0;

    private Transform gp;

    private void Start()
    {
        getImages();

        gp = transform.Find("rotation").transform.Find("GunPoint");
        selectedPics[selectedPics.Length-1].color = Color.gray;

        if (guns[selected] != null && gp.transform.childCount == 0) activeGun = Instantiate(guns[selected], gp);
    }

    void Update()
    {
        if (Shooting.onCooldown() && Sword.onCooldown())
        {
            selectSlot();
            selectedGun();
        }
    }

    private void LateUpdate()
    {
        if (!Shooting.onCooldown() || !Sword.onCooldown()) selectedPics[selected].color = Color.red;
        else selectedPics[selected].color = Color.white;
    }

    private void getImages()
    {
        selectedPics[0] = transform.Find("PlayerCanvas").Find("gun1").gameObject.GetComponent<Image>();
        selectedPics[1] = transform.Find("PlayerCanvas").Find("gun2").gameObject.GetComponent<Image>();

        if (guns[0] != null) selectedPics[0].sprite = guns[0].GetComponent<SpriteRenderer>().sprite;
        if (guns[1] != null) selectedPics[1].sprite = guns[1].GetComponent<SpriteRenderer>().sprite;
    }

    public void setSelected(GameObject gun, GameObject active)
    {
        if (guns[0] == null)
        {
            guns[0] = gun;
            selectedPics[0].sprite = gun.GetComponent<SpriteRenderer>().sprite;
            if (activeGun != null) Destroy(activeGun);
            activeGun = active;
            selected = 0;
        }
        else if (guns[0] != null && guns[1] == null)
        {
            guns[1] = gun;
            selectedPics[1].sprite = gun.GetComponent<SpriteRenderer>().sprite;
            if (activeGun != null) Destroy(activeGun);
            activeGun = active;
            selected = 1;
        }
        else
        {
            guns[selected] = gun;
            selectedPics[selected].sprite = gun.GetComponent<SpriteRenderer>().sprite;
            if (activeGun != null) Destroy(activeGun);
            activeGun = active;
        }
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

        if (selected > guns.Length - 1) selected = 0;
        else if (selected < 0) selected = guns.Length - 1;

        if (Input.GetKeyDown(KeyCode.Alpha1)) selected = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) selected = 1;
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
