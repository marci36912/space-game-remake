using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStats : MonoBehaviour
{
    private static List<Gun> gunList = new List<Gun>();

    private void Awake()
    {
        //name, damage, velocity, spread, bulletcount, cd
        Gun pistol = new Gun("Pistol", 30, 13, 0, 1, 2f);           //0
        Gun ar = new Gun("Assault Riffle", 40, 15, 0, 1, 1.5f);     //1
        Gun shotgun = new Gun("Shotgun", 10, 11, 0.4f, 9, 2f);     //2

        gunList.Add(pistol);
        gunList.Add(ar);
        gunList.Add(shotgun);
    }

    public static Gun ReturnGun(int n)
    {
        return gunList[n];
    }
}
