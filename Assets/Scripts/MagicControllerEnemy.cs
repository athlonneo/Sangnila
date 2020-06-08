using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicControllerEnemy : MonoBehaviour
{
    public int damagePerAttack = 10;
    public float range = 1f;

    float timer;
    PlayerHealth playerHealth;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null && playerHealth.currentHealth > 0)
            {
                Attack();
            }
        }
        if (!other.gameObject.CompareTag("Enemy")){
            Destroy(gameObject, 0f);
        }    
    }

    void Attack()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damagePerAttack);
        }
    }
}
