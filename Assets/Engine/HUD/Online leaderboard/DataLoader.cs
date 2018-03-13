﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataLoader : MonoBehaviour {
    public UserData userdata;
    //public FloatVariable highscore;
    public int NumberOfTopScoresToLoad;
    private Dictionary<string, string> achievements = new Dictionary<string, string>();
    Dictionary<string, int> result;
    private List<Dictionary<string, int>> games = new List<Dictionary<string, int>>();
    private string userAchievementsURL = "http://localhost/sweetboi/user_achievements.php?username=";
    private string userScoresURL = "http://localhost/sweetboi/user_scores.php?username=";
    //private string JSONGameResultsURL = "http://localhost/sweetboi/game_results.php?username=";

    public void LoadData() {
        StartCoroutine(LoadAchievements());
        StartCoroutine(LoadScores(NumberOfTopScoresToLoad));
    }

    IEnumerator LoadAchievements() {
        Debug.Log("Loading achievements.. ");
        //wait until there is a user defined in userdata script
        yield return new WaitUntil(() => !string.IsNullOrEmpty(userdata.getUsername()));
        WWW userAchievements = new WWW(userAchievementsURL + userdata.getUsername());
        yield return userAchievements;
        string userAchievementsString = userAchievements.text;
        List<string> rawAchievements = splitByString(userAchievementsString, ";;;");
        foreach (string rawAchievement in rawAchievements) {
            string title = splitByString((splitByString((rawAchievement), "|||")[0]), ":::")[1];
            string description = splitByString((splitByString((rawAchievement), "|||")[1]), ":::")[1];
            achievements.Add(title, description);
        }
        Debug.Log("..achievements loaded ");
    }
    IEnumerator LoadScores(int limit) {
        Debug.Log("Loading scores.. ");
        //wait until there is a user defined in userdata script
        yield return new WaitUntil(() => !string.IsNullOrEmpty(userdata.getUsername()));
        WWW userScores = new WWW(userScoresURL + userdata.getUsername() + "&score_limit=" + limit.ToString());
        yield return userScores;
        string userScoresString = userScores.text;
        List<string> rawScores = splitByString(userScoresString, ";;;");
        foreach (string rawScore in rawScores) {
            result = new Dictionary<string, int>();
            result.Add(splitByString((splitByString((rawScore), "|||")[0]), ":::")[0], Int32.Parse(splitByString((splitByString((rawScore), "|||")[0]), ":::")[1]));
            result.Add(splitByString((splitByString((rawScore), "|||")[1]), ":::")[0], Int32.Parse(splitByString((splitByString((rawScore), "|||")[1]), ":::")[1]));
            result.Add(splitByString((splitByString((rawScore), "|||")[2]), ":::")[0], Int32.Parse(splitByString((splitByString((rawScore), "|||")[2]), ":::")[1]));
            result.Add(splitByString((splitByString((rawScore), "|||")[3]), ":::")[0], Int32.Parse(splitByString((splitByString((rawScore), "|||")[3]), ":::")[1]));
            games.Add(result);
          }
        userdata.setHighscore(LoadUserHighscore(games));
        userdata.setHighscore(userdata.getHighscore());
        Debug.Log("..scores loaded and set ");
    }

    private List<string> splitByString(string stringToSplit, string splitter) {
        List<string> splittedStrings = new List<string>(stringToSplit.Split(new[] { splitter }, StringSplitOptions.RemoveEmptyEntries));
        return splittedStrings;
    }

    private int LoadUserHighscore(List<Dictionary<string, int>> games) {
        Debug.Log("Loading " + userdata.getUsername() + " highscore.. ");
        int maxScore = 0;
        for (int i = 0; i < games.Count; i++) {
            if (games[i].Values.ToArray()[0] > maxScore) {
                maxScore = games[i]["score"];
            }
        }
        return maxScore;
    }
}
