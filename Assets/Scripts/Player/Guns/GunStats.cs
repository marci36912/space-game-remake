using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStats : MonoBehaviour
{
    private static List<Gun> gunList = new List<Gun>();

    private void Awake()
    {
        //name, damage, velocity, spread, bulletcount, cd, magazine
        Gun pistol = new Gun("Pistol", 15, 13, 0, 1, 1.4f, 4);           //0
        Gun ar = new Gun("Assault Riffle", 20, 15, 0, 1, 1.8f, 8);     //1
        Gun shotgun = new Gun("Shotgun", 6, 11, 30f, 9, 2.1f, 3);     //2

        gunList.Add(pistol);
        gunList.Add(ar);
        gunList.Add(shotgun);
    }

    public static Gun ReturnGun(int n)
    {
        return gunList[n];
    }
}
