using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class PauseManager : MonoBehaviour
{
    public AudioMixerSnapshot pause;
    public AudioMixerSnapshot play;

    Canvas canvas;
    GameObject player;
    public AudioListener audioListener;
    PlayerAttack playerAttack;
    PlayerMagic playerMagic;

    void Awake()
    {
        canvas = GetComponent<Canvas>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerAttack = player.GetComponent<PlayerAttack>();
        playerMagic = player.GetComponent<PlayerMagic>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {    
            Pause();
        }
    }

    public void Pause()
    {
        canvas.enabled = !canvas.enabled;

        Time.timeScale = Time.timeScale == 0 ? 1 : 0;

        if (audioListener.enabled)
        {
            if(Time.timeScale == 0)
            {
                pause.TransitionTo(0.1f);
                playerAttack.enabled = false;
                playerMagic.enabled = false;
            }
            else
            {
                play.TransitionTo(0.1f);
                playerAttack.enabled = true;
                playerMagic.enabled = true;
            }
        }
    }

    public void Quit()
    {
        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
