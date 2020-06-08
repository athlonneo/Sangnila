using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static int pickupCount;
    public static int maxPickup = 1;
    public static bool isGameOver;

    public PlayerHealth playerHealth;
    public float restartDelay = 5f;
    //public Canvas minimapCanvas;
    public Animator loseAnim;
    public Animator winAnim;
    public string scene = "Test";

    float restartTimer;

    void Awake()
    {
        pickupCount = 0;
        isGameOver = false;
        EnemyManager.enemyCount = 0;

        //minimapCanvas.enabled = true;
    }

    void Update()
    {
        if(pickupCount >= maxPickup)
        {
            Win();
        }

        if(playerHealth.currentHealth <= 0)
        {
            Lose();
        }
    }

    void Win()
    {
        //minimapCanvas.enabled = false;
        winAnim.SetTrigger("Win");
        isGameOver = true;
        restartTimer += Time.deltaTime;
        if (restartTimer >= restartDelay)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }

    void Lose()
    {
        //minimapCanvas.enabled = false;
        loseAnim.SetTrigger("Lose");
        isGameOver = true;
        restartTimer += Time.deltaTime;
        if (restartTimer >= restartDelay)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }

}
