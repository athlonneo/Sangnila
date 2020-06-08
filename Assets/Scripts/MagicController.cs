using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour
{
    public int damagePerAttack = 20;
    public float range = 1f;

    float timer;
    EnemyHealth enemyHealth;

    ParticleSystem exp;

    private void Awake()
    {
        exp = GetComponentInChildren<ParticleSystem>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyHealth = other.GetComponent<EnemyHealth>();

            if (enemyHealth != null && enemyHealth.currentHealth > 0)
            {
                Attack();
            }
        }

        if (!other.gameObject.CompareTag("Player"))
        {
            if (exp)
            {
                exp.Play();
            }
            Destroy(gameObject, 0.1f);
        }
    }

    void Attack()
    {
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damagePerAttack);
        }
    }
}
