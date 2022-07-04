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

    private bool spawned = false;

    private void Start()
    {
        Instance = this;
    }

    public void spawnBuffs()
    {
        if (!spawned)
        {
            Instantiate(getRandomItem(), spawnpoints[0].position, Quaternion.identity);
            Instantiate(getRandomItem(), spawnpoints[1].position, Quaternion.identity);
            Instantiate(getRandomItem(), spawnpoints[2].position, Quaternion.identity);
            spawned = true;
        }
    }

    public void resetBuff()
    {
        spawned = false;
    }

    private GameObject getRandomItem()
    {
        GameObject random = buffs[Random.Range(0, buffs.Length)];
        if (tmp == null)
        {
            tmp = random;
            return tmp;
        }
        else if(tmp2 == null)
        {
            tmp2 = tmp == random ? getRandomItem() : random;
            return tmp2;
        }

        if (tmp == random || tmp2 == random)
        {
            getRandomItem();
        }
        return random;
    }
}
