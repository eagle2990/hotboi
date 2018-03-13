using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour {
    public UserData userdata;
    public int TopScoresToLoad;
    private Dictionary<string, string> achievements = new Dictionary<string, string>();
    Dictionary<string, int> result;
    private List<Dictionary<string, int>> games = new List<Dictionary<string, int>>();
    private string userAchievementsURL = "http://localhost/sweetboi/user_achievements.php?username=";
    private string userScoresURL = "http://localhost/sweetboi/user_scores.php?username=";
    int maxScore = 0;

    public void LoadData() {
        StartCoroutine(LoadAchievements());
        StartCoroutine(LoadScores(TopScoresToLoad));
        print("User data loading complete!");
    }

    IEnumerator LoadAchievements() {
        //wait until there is a user defined in userdata script
        yield return new WaitUntil(() => !string.IsNullOrEmpty(userdata.getUsername()));
        WWW userAchievements = new WWW(userAchievementsURL + userdata.getUsername());
        yield return userAchievements;
        string userAchievementsString = userAchievements.text;
        List<string> rawAchievements = splitByString(userAchievementsString, ";;;");
        //split to => achievement_title:::Not my thing|||achievement_description:::Kill 50 superfans
        //split to => achievement_title:::The n00b|||achievement_description:::Kill 10 superfans
        foreach (string rawAchievement in rawAchievements) {
            //split to => achievement_title:::Not my thing                                               
            //split to => achievement_description:::Kill 50 superfans
            string title = splitByString((splitByString((rawAchievement), "|||")[0]), ":::")[1];
            string description = splitByString((splitByString((rawAchievement), "|||")[1]), ":::")[1];
            //print("Achievement: " + title + " - " + description);
            achievements.Add(title, description);
        }
    }
    IEnumerator LoadScores(int limit) {
        //wait until there is a user defined in userdata script
        yield return new WaitUntil(() => !string.IsNullOrEmpty(userdata.getUsername()));
        WWW userScores = new WWW(userScoresURL + userdata.getUsername() + "&scoreLimit=" + limit.ToString());
        yield return userScores;
        string userScoresString = userScores.text;
        List<string> rawScores = splitByString(userScoresString, ";;;");
        // split to => score:::1102|||kills:::123|||playtime:::142|||level:::2
        // split to => score:::997|||kills:::12|||playtime:::241|||level:::1
        foreach (string rawScore in rawScores) {
            result = new Dictionary<string, int>();
            int score = Int32.Parse(splitByString((splitByString((rawScore), "|||")[0]), ":::")[1]);
            int kills = Int32.Parse(splitByString((splitByString((rawScore), "|||")[1]), ":::")[1]);
            int playtime = Int32.Parse(splitByString((splitByString((rawScore), "|||")[2]), ":::")[1]);
            int level = Int32.Parse(splitByString((splitByString((rawScore), "|||")[3]), ":::")[1]);
            result.Add("score", score);
            result.Add("kills", kills);
            result.Add("playtime", playtime);
            result.Add("level", level);
            games.Add(result);
          }
    }

    private List<string> splitByString(string stringToSplit, string splitter) {
        List<string> splittedStrings = new List<string>(stringToSplit.Split(new[] { splitter }, StringSplitOptions.RemoveEmptyEntries));
        return splittedStrings;
    }
}
