using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private static GameObject[] guns = new GameObject[2];   
    private GameObject[] activeGuns = new GameObject[2];   
    private Image[] inventoryImage = new Image[2];

    private int selected = 0;
    private int tmp = 0;

    private float switchCooldown = 0;

    private void Start()
    {
        getImages();

        activeGuns[0] = GameObject.Find("gun1");
        activeGuns[1] = GameObject.Find("gun2");
        inventoryImage[inventoryImage.Length-1].color = Color.gray;

        if (guns[0] != null && activeGuns[0].transform.childCount == 0) 
            Instantiate(guns[0], activeGuns[0].transform);
        if (guns[1] != null && activeGuns[1].transform.childCount == 0) 
            Instantiate(guns[1], activeGuns[1].transform);

        activeGuns[0].SetActive(true);
        activeGuns[1].SetActive(false);
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

        inventoryImage[0].SetNativeSize();
        inventoryImage[1].SetNativeSize();
    }

    public void setSelected(GameObject gun)
    {
        if (guns[0] == null)
        {
            guns[0] = gun;
            inventoryImage[0].sprite = gun.GetComponent<SpriteRenderer>().sprite;
            inventoryImage[0].SetNativeSize();
            if (activeGuns[0].transform.childCount > 0) Destroy(activeGuns[0].transform.GetChild(0));
            Instantiate(guns[0], activeGuns[0].transform);
            selected = 0;
        }
        else if (guns[0] != null && guns[1] == null)
        {
            guns[1] = gun;
            inventoryImage[1].sprite = gun.GetComponent<SpriteRenderer>().sprite;
            inventoryImage[1].SetNativeSize();
            if (activeGuns[1].transform.childCount > 0) Destroy(activeGuns[1].transform.GetChild(0));
            Instantiate(guns[1], activeGuns[1].transform);
            selected = 1;
        }
        else
        {
            guns[selected] = gun;
            inventoryImage[selected].sprite = gun.GetComponent<SpriteRenderer>().sprite;
            inventoryImage[selected].SetNativeSize();
            if (activeGuns[selected].transform.childCount > 0) Destroy(activeGuns[selected].transform.GetChild(0));
            Instantiate(guns[selected], activeGuns[selected].transform);
        }
    }
    private void selectedGun()
    {
        if (tmp == selected) return;
        else if(switchCooldown < Time.time)
        { 
            tmp = selected;

            activeGuns[0].SetActive(!activeGuns[0].activeInHierarchy);
            activeGuns[1].SetActive(!activeGuns[1].activeInHierarchy);
            
            selectedColor();
            switchCooldown = Time.time + 0.2f;
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
