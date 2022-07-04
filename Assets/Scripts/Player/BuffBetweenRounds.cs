using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffBetweenRounds : MonoBehaviour
{
    public static BuffBetweenRounds Instance;

    [SerializeField] private Transform[] spawnpoints;
    [SerializeField] private GameObject[] buffs;
    private GameObject tmp;
    private GameObject tmp2;

    private GameObject buff1;
    private GameObject buff2;
    private GameObject buff3;

    private bool spawned = false;

    private void Start()
    {
        Instance = this;
    }

    public void spawnBuffs()
    {
        if (!spawned)
        {
            buff1 = Instantiate(getRandomItem(), spawnpoints[0].position, Quaternion.identity);
            buff2 = Instantiate(getRandomItem(), spawnpoints[1].position, Quaternion.identity);
            buff3 = Instantiate(getRandomItem(), spawnpoints[2].position, Quaternion.identity);
            spawned = true;
        }
    }

    public void resetBuff()
    {
        if (buff1 != null) Destroy(buff1);
        if (buff2 != null) Destroy(buff2);
        if (buff3 != null) Destroy(buff3);
        spawned = false;
    }

    private GameObject getRandomItem()
    {
        GameObject random = buffs[Random.Range(0, buffs.Length)];
        Debug.Log(random + " random");
        if (tmp == null)
        {
            tmp = random;
            Debug.Log(tmp + " tmp");
            return tmp;
        }
        else if(tmp2 == null)
        {
            tmp2 = tmp == random ? getRandomItem() : random;
            Debug.Log(tmp2 + " tmp2");
            return tmp2;
        }

        if (tmp != random && tmp2 != random)
        {
            return random;
        }
        return getRandomItem();
    }
}
