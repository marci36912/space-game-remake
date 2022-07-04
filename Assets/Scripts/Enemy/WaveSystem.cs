using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSystem : MonoBehaviour
{
    public static WaveSystem Instance;

    [SerializeField] private GameObject teleport;

    [SerializeField] private Transform[] spawns;
    [SerializeField] private GameObject[] enemies;

    [SerializeField] private Animator textAnim;
    [SerializeField] private TextMeshProUGUI roundText;

    private int maxRound = 5;
    private int round = 0;

    private int maxEnemy = 6;
    private int spawnedEnemy = 0;
    private int currentEnemy = 0;

    private float cooldown = 0;
    private float betweenEnemies = 3.5f;
    private float betweenRounds = 10;

    private bool pickedUp = false;

    public void pickedUpBuff()
    {
        pickedUp = true;
    }
    private void Start()
    {
        setRoundText();
        Instance = this;
    }

    private void FixedUpdate()
    {
        roundManager();
    }

    private void setRoundText()
    {
        roundText.text = "ROUND " + (round + 1);
    }

    private void roundManager()
    {
        if (round < maxRound)
        {
            if (onSpawnCooldown() && !maxCount())
            {
                pickedUp = false;
                spawnenemy();
            }
            else if (maxCount() && killedAll())
            {
                nextRound();
            }
        }
        else
        {
            if (teleport.activeInHierarchy == false)
            {
                roundText.text = "Opened teleport";
                textAnim.Play("round_text", 0, 0);
                teleport.SetActive(true);
            }
        }
    }

    private void nextRound()
    {
        if (!pickedUp)
        {
            BuffBetweenRounds.Instance.spawnBuffs();
            return;
        }

        cooldown = Time.time + betweenRounds;
        spawnedEnemy = 0;
        round++;
        maxEnemy++;


        if (round < maxRound)
        {
            setRoundText();
            textAnim.Play("round_text", 0, 0);
        }
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
