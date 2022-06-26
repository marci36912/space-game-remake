using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private Transform[] weaponsSpawn;
    [SerializeField] private GameObject[] buffs;
    [SerializeField] private Transform[] buffsSpawn;

    private GameObject tmp;

    private void Start()
    {
        spawnItem(getGun(), weaponsSpawn[0]);
        spawnItem(getGun(), weaponsSpawn[1]);
        spawnItem(getGun(), buffsSpawn[0]);
        spawnItem(getGun(), buffsSpawn[1]);
    }

    private void spawnItem(GameObject item, Transform place)
    {
        Instantiate(item, place.position, Quaternion.identity);
    }

    private GameObject getBuff()
    {
        GameObject random = buffs[Random.Range(0, weapons.Length)];
        tmp = tmp == random ? getBuff() : random;
        return tmp;
    }
    private GameObject getGun()
    {
        GameObject random = weapons[Random.Range(0, weapons.Length)];
        tmp = tmp == random ? getGun() : random;
        return tmp;
    }
}
