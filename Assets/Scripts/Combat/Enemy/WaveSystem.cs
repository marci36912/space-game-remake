using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private Transform[] spawns;
    [SerializeField] private GameObject[] enemies;

    private int maxRound = 5;
    private int round = 0;

    private int maxEnemy = 6;
    private int spawnedEnemy = 0;
    private int currentEnemy = 0;

    private float cooldown = 0;
    private float betweenEnemies = 3.5f;
    private float betweenRounds = 10;

    private void FixedUpdate()
    {
        roundManager();
    }

    private void roundManager()
    {
        if (round != maxRound)
        {
            if (onSpawnCooldown() && !maxCount())
            {
                spawnenemy();
                Debug.Log(spawnedEnemy + " enemy");
            }
            else if (maxCount() && killedAll())
            {
                nextRound();
                Debug.Log(round + " round");
            }
        }
    }

    private void nextRound()
    {
        cooldown = Time.time + betweenRounds;
        spawnedEnemy = 0;
        round++;
        maxEnemy++;
    }

    #region bools
    private bool onSpawnCooldown()
    {
        return cooldown < Time.time;
    }

    private bool maxCount()
    {
        return spawnedEnemy == maxEnemy;
    }

    private bool killedAll()
    {
        return currentEnemy == 0;
    }
    #endregion

    private void spawnenemy()
    {
        Instantiate(getEnemy(), getSpawn(), Quaternion.identity, transform);
        spawnedEnemy++;
        currentEnemy++;
        cooldown = Time.time + betweenEnemies;
    }

    #region randoms
    private GameObject getEnemy()
    {
        return enemies[Random.Range(0, enemies.Length)];
    }
    private Vector3 getSpawn()
    {
        return spawns[Random.Range(0, spawns.Length)].position;
    }
    #endregion

    public void enemyDeath()
    {
        currentEnemy--;
    }
}
