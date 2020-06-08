using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    public void Start()
    {
        nav.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.currentHealth > 0 && nav.enabled && enemyHealth.currentHealth > 0 && !GameOverManager.isGameOver)
        {
            nav.SetDestination(player.position);
        }
        else
        {
            Stop();
        }
    }

    public void Stop()
    {
        nav.enabled = false;
    }

}

