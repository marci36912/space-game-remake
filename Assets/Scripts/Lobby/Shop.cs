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
        spawnItem(getRandomItem(weapons), weaponsSpawn[0]);
        spawnItem(getRandomItem(weapons), weaponsSpawn[1]);
        spawnItem(getRandomItem(buffs), buffsSpawn[0]);
        spawnItem(getRandomItem(buffs), buffsSpawn[1]);
    }

    private void spawnItem(GameObject item, Transform place)
    {
        Instantiate(item, place.position, Quaternion.identity);
    }

    private GameObject getRandomItem(GameObject[] items)
    {
        GameObject random = items[Random.Range(0, items.Length)];
        tmp = tmp == random ? getRandomItem(items) : random;
        return tmp;
    }
}
