using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static int enemyCount = 0;
    public int maxEnemy = 5;

    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    bool invoked = false;

    void Update()
    {
        if (enemyCount >= maxEnemy)
        {
            CancelInvoke();
            invoked = false;
        }
        else
        {
            if (!invoked)
            {
                InvokeRepeating("Spawn", spawnTime, spawnTime);
                invoked = true;
            }      
        }
    }

    void Spawn()
    {
        if (playerHealth.currentHealth <= 0)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        enemyCount++;
    }
}
