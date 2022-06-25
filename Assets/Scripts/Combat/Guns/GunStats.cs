using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStats : MonoBehaviour
{
    private static List<Gun> gunList = new List<Gun>();

    private void Awake()
    {
        //name, damage, velocity, spread, bulletcount, cd
        Gun pistol = new Gun("Pistol", 30, 10, 0, 1, 2f);     //0
        Gun ar = new Gun("Assault Riffle", 40, 13, 0, 1, 1.5f);   //1
        Gun shotgun = new Gun("Shotgun", 5, 7, 0.3f, 5, 2.3f);    //2

        gunList.Add(pistol);
        gunList.Add(ar);
        gunList.Add(shotgun);
    }

    public static Gun ReturnGun(int n)
    {
        return gunList[n];
    }
}
