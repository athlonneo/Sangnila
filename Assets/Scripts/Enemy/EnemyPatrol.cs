using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent nav;
    private bool isChasing;

    GameObject player;
    PlayerHealth playerHealth;

    public int damagePerAttack = 20;
    public float timeBetweenAttacks = 5f;
    public float range = 10f;
    public GameObject magicPrefab;
    public Transform magicSpawn;
    float timer;
    void Start()
    {
        isChasing = false;
        nav = GetComponent<NavMeshAgent>();
        nav.autoBraking = false;  
        GotoNextPoint();
    }

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        nav.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    void Update()
    {
        if (nav.isActiveAndEnabled)
        {
            if (isChasing && playerHealth.currentHealth > 0)
            {
                transform.LookAt(player.transform);
                nav.ResetPath();
                timer += Time.deltaTime;
                if (timer >= timeBetweenAttacks)
                {
                    Attack();
                }
                if (Vector3.Distance(points[destPoint].position, player.transform.position) > 20)
                {
                    isChasing = false;
                }
            }

            if (!nav.pathPending && nav.remainingDistance < 0.5f && nav.enabled && !isChasing)
            {
                GotoNextPoint();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isChasing = true;
        }
    }

    void Attack()
    {
        timer = 0f;
        //Quaternion newRotation = Quaternion.LookRotation(player.transform.position);
        var magicBall = (GameObject)Instantiate(magicPrefab, magicSpawn.transform) as GameObject;
        Rigidbody rb = magicBall.GetComponent<Rigidbody>();
        rb.AddForce(magicBall.transform.forward * 10, ForceMode.Impulse);
        Destroy(magicBall, 1.5f);
    }
}
