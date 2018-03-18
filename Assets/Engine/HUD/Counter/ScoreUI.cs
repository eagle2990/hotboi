using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public FloatVariable score;
    public FloatVariable kills;
    public FloatVariable highScore;
    public UserData userData;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI killsText;
    public TextMeshProUGUI highScoreText;

    private float previousScoreValue;
    private float previousKillsValue;
    private float previousHighScoreValue;


    private void Start()
    {
        //reset score and kills when sweetboi gameobject starts
        //highScore.Value = userData.GetHighscore();
        score.Value = 0;
        kills.Value = 0;
        scoreText.text = string.Format("{0}", score.Value);
        killsText.text = string.Format("x {0}", kills.Value);
        highScoreText.text = string.Format("{0}", userData.GetHighscore());
        previousScoreValue = score.Value;
        previousKillsValue = kills.Value;
        previousHighScoreValue = (float)(userData.GetHighscore());
    }

    private void Update()
    {
        if (IsDifferentFromPreviosValue(previousScoreValue, score))
        {
            scoreText.text = string.Format("{0}", score.Value);
        }
        if (IsDifferentFromPreviosValue(previousKillsValue, kills))
        {
            killsText.text = string.Format("x {0}", kills.Value);
        }
        if (IsBiggerFromPreviousValue(previousHighScoreValue, highScore)) 
        {
            highScoreText.text = string.Format("{0}", highScore.Value);
        }
        if (IsScoreBiggerThanHighScore(score.Value, highScore)) {
            highScore.SetValue(score);
        }
        if (IsGlobalHighscoreBiggerThanLocalHighscore(userData.GetHighscore(), highScore)) {
            highScore.SetValue(userData.GetHighscore());
        }
    }

    private bool IsGlobalHighscoreBiggerThanLocalHighscore(int globalHighscore, FloatVariable highScore) {
        return globalHighscore > highScore.Value;
    }

    private bool IsDifferentFromPreviosValue(float previousValue, FloatVariable current)
    {
        return current.Value != previousValue;
    }
    //check for new highscore
    private bool IsBiggerFromPreviousValue(float previousValue, FloatVariable current) 
    {
        return current.Value > previousValue;
    }
    //check if current score is bigger than highscore
    private bool IsScoreBiggerThanHighScore(float score, FloatVariable highScore) {
        return score > highScore.Value;
    }
}
