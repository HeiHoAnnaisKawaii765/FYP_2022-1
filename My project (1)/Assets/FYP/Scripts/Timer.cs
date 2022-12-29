using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public Text time;
    public float timeRemaining = 10;
    public TMP_Text tmText;
    private void Update()
    {
        tmText.text = (timeRemaining / 60).ToString("00") + ":" + (timeRemaining % 60).ToString("00");
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
    }
}
