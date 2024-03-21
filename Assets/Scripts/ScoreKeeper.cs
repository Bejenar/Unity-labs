using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private int score = 0;

    private void Start()
    {
        Reset();
    }

    public void Score(int points)
    {
        score += points;
        text.text = "Score: " + score;
    }

    public void Reset()
    {
        score = 0;
        text.text = "Score: 0";
    }
}
