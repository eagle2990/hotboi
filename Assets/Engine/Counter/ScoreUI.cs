using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public FloatVariable score;
    public FloatVariable kills;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI killsText;

    private float previousScoreValue;
    private float previousKillsValue;


    private void Start()
    {
        scoreText.text = string.Format("Score: {0}", score.Value);
        killsText.text = string.Format("Kills: {0}", kills.Value);
        previousScoreValue = score.Value;
        previousKillsValue = kills.Value;
    }

    private void Update()
    {
        if (IsDifferentFromPreviosValue(previousScoreValue, score))
        {
            scoreText.text = string.Format("Score: {0}", score.Value);
        }

        if (IsDifferentFromPreviosValue(previousKillsValue, kills))
        {
            killsText.text = string.Format("Kills: {0}", kills.Value);
        }
    }

    private bool IsDifferentFromPreviosValue(float previousValue, FloatVariable current)
    {
        return current.Value != previousValue;
    }
}
