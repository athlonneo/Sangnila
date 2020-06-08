using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioSource enemyAudio;
    public AudioClip deathClip;
    public AudioClip hurtClip;
    public float sinkingTime = 1f;
    public float displayTime = 1f;
    //public Camera mainCamera;

    Animator anim;
    bool isDead;
    bool isSinking;
    float timer;
    bool isAttacked;
    Canvas canvas;
    Slider slider;
    

    void Awake()
    {
        anim = GetComponent<Animator>();
        canvas = GetComponentInChildren<Canvas>();
        slider = GetComponentInChildren<Slider>();

        canvas.enabled = false;
        currentHealth = startingHealth;
        enemyAudio.clip = hurtClip;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isAttacked && timer > displayTime)
        {
            isAttacked = false;
            canvas.enabled = false;
        }

        if (isSinking && timer > sinkingTime)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }

        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    public void TakeDamage(int amount)
    {
        if (isDead)
        {
            return;
        }

        enemyAudio.Play();
        currentHealth -= amount;
        timer = 0;
        isAttacked = true;
        canvas.enabled = true;
        slider.value = currentHealth;
    }

    void Death()
    {
        isDead = true;
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
        StartSinking();
        ScoreManager.score += scoreValue;
    }

    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;

        timer = 0;
        isSinking = true;

        EnemyManager.enemyCount--;

        Destroy(gameObject, 2f);
    }
}
