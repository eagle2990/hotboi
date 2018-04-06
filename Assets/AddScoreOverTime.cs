using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreOverTime : MonoBehaviour {

    [Range(0, 10)]
    public int scoreToAdd;
    [Range(0f, 10f)]
    public float addScoreTimer;
    public FloatVariable score;

    private float timer;

    private void Start() {
        timer = 0f;
    }

    void Update () {
        timer += Time.deltaTime;
        if (timer >= addScoreTimer) {
            score.Add(scoreToAdd);
            timer = 0f;
        }
	}

}
