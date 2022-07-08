using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private static GameObject[] guns = new GameObject[2];   
    private Image[] inventoryImage = new Image[2];

    private GameObject activeGun;       //this script destroys the currect active gun and instantiates a new one insted of that. I dont think thats ok for the performance
    private Transform gunPoint;         //anyway
    private int selected = 0;
    private int tmp = 0;    //temporary int, only changes value on gun switching

    private void Start()
    {
        getImages();

        gunPoint = transform.Find("rotation").transform.Find("GunPoint");
        inventoryImage[inventoryImage.Length-1].color = Color.gray;

        if (guns[selected] != null && gunPoint.transform.childCount == 0) activeGun = Instantiate(guns[selected], gunPoint);
    }

    void Update()
    {
        if (Shooting.onCooldown() && Sword.onCooldown())
        {
            selectSlot();
            selectedGun();
        }
    }

    private void FixedUpdate()
    {
        if (!Shooting.onCooldown() || !Sword.onCooldown()) inventoryImage[selected].color = Color.red;
        else inventoryImage[selected].color = Color.white;
    }

    private void getImages()
    {
        inventoryImage[0] = transform.Find("PlayerCanvas").Find("gun1").gameObject.GetComponent<Image>();
        inventoryImage[1] = transform.Find("PlayerCanvas").Find("gun2").gameObject.GetComponent<Image>();

        if (guns[0] != null) inventoryImage[0].sprite = guns[0].GetComponent<SpriteRenderer>().sprite;
        if (guns[1] != null) inventoryImage[1].sprite = guns[1].GetComponent<SpriteRenderer>().sprite;
    }

    public void setSelected(GameObject gun, GameObject active)
    {
        if (guns[0] == null)
        {
            guns[0] = gun;
            inventoryImage[0].sprite = gun.GetComponent<SpriteRenderer>().sprite;
            if (activeGun != null) Destroy(activeGun);
            activeGun = active;
            selected = 0;
        }
        else if (guns[0] != null && guns[1] == null)
        {
            guns[1] = gun;
            inventoryImage[1].sprite = gun.GetComponent<SpriteRenderer>().sprite;
            if (activeGun != null) Destroy(activeGun);
            activeGun = active;
            selected = 1;
        }
        else
        {
            guns[selected] = gun;
            inventoryImage[selected].sprite = gun.GetComponent<SpriteRenderer>().sprite;
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

            if (gunPoint.childCount != 0) Destroy(activeGun);

            if (guns[selected] != null) activeGun = Instantiate(guns[selected], gunPoint);
                
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
        for (int i = 0; i < inventoryImage.Length; i++)
        {
            if (i == selected) inventoryImage[i].color = Color.white;
            else inventoryImage[i].color = Color.gray;
        }
    }
}
