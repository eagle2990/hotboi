﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathScreenController : MonoBehaviour {
    public GameObject deathScreen;
    public TextMeshProUGUI scoreTable;
    public UserData userData;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void ShowDeathScreen() {
        //ShowUserScores();
        ShowUserScores();
        deathScreen.SetActive(true);
    }
    public void HideDeathScreen() {
        deathScreen.SetActive(false);
    }
    //limit - max number of scores to be shown
    public void ShowUserScores() {
        string ScoreFieldText = "";
        List<Dictionary<string, int>> games = userData.GetScores();
        for (int i = 0; i < games.Count; i++) {
                 ScoreFieldText += i+1 + ". " + userData.GetUsername() + ": " + games[i]["score"] + "\n";
        }
        scoreTable.SetText(ScoreFieldText);
    }
    public void ShowGlobalScores() {
        string ScoreFieldText = "";
        List<Dictionary<string, int>> globalGames = userData.GetGlobalScores();
        for (int i = 0; i < globalGames.Count; i++) {
            //ScoreFieldText += i + 1 + ": " + globalGames[i]["score"] + "\n";
            foreach (KeyValuePair<string, int> kvp in globalGames[i]) {
                //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                ScoreFieldText += string.Format(i+1 + ". " + "{0}: {1}", kvp.Key, kvp.Value + "\n");
            }
        }
        scoreTable.SetText(ScoreFieldText);
    }

}
