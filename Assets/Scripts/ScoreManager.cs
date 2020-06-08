using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text> ();
    }

    private void Update()
    {
        text.SetText("Score: {0}", score);
    }
}
