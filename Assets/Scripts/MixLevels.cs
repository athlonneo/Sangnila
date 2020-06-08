using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixLevels : MonoBehaviour
{
    public AudioMixer masterMixer;
    Canvas canvas;
    // Start is called before the first frame update
    void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    public void SetSfxLvl(float sfxLvl)
    {
        if (canvas)
        {
            masterMixer.SetFloat("SFXVol", sfxLvl);
        }
    }
    // Update is called once per frame
    public void SetMusicLevel(float musicLvl)
    {
        if (canvas)
        {
            masterMixer.SetFloat("BGMVol", musicLvl);
        }
    }
}
