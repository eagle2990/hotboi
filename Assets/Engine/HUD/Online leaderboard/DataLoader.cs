using System;
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
    private List<Dictionary<string, int>> globalGames = new List<Dictionary<string, int>>();
    private string userAchievementsURL = "https://sweetboi.000webhostapp.com/user_achievements.php?username=";
    private string userScoresURL = "https://sweetboi.000webhostapp.com/user_scores.php?username=";
    private string globalScoresURL = "https://sweetboi.000webhostapp.com/global_scores.php?score_limit=";

    //private string JSONGameResultsURL = "http://localhost/sweetboi/game_results.php?username=";

    private void Start() {
    }

    public void LoadStartingData() {
        StartCoroutine(LoadAchievements());
        StartCoroutine(LoadUserHighScoreAtStart());

    }
    public void LoadPrivateData() {
        StartCoroutine(LoadScores(NumberOfTopScoresToLoad));
    }
    //To be called after death
    public void LoadGlobalData() {
        StartCoroutine(LoadGlobalScores(NumberOfTopScoresToLoad));
    }

    //For loading user achievements, must be done right after login.
    IEnumerator LoadAchievements() {
        Debug.Log("Loading achievements.. ");
        //wait until there is a user defined in userdata script
        yield return new WaitUntil(() => !string.IsNullOrEmpty(userdata.GetUsername()));
        WWW userAchievements = new WWW(userAchievementsURL + userdata.GetUsername());
        yield return userAchievements;
        string userAchievementsString = userAchievements.text;
        List<string> rawAchievements = splitByString(userAchievementsString, ";;;");
        foreach (string rawAchievement in rawAchievements) {
            string title = splitByString((splitByString((rawAchievement), "|||")[0]), ":::")[1];
            string description = splitByString((splitByString((rawAchievement), "|||")[1]), ":::")[1];
            if (!achievements.ContainsKey(title)) {
                achievements.Add(title, description);
            } else {
                Debug.Log("Tried to load same achievement multiple times ");
            }
        }
        Debug.Log("..achievements loaded ");
    }

    //For loading scores at the end of the game - after new score has been uploaded.
    IEnumerator LoadScores(int limit) {
        Debug.Log("Loading final scores.. ");
        //wait until there is a user defined in userdata script
        yield return new WaitUntil(() => !string.IsNullOrEmpty(userdata.GetUsername()));
        WWW userScores = new WWW(userScoresURL + userdata.GetUsername() + "&score_limit=" + limit.ToString());
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
        //TODO
        userdata.SetHighscore(LoadUserHighscore(games));
        //userdata.SetHighscore(userdata.GetHighscore());
        userdata.SetScores(games);
        Debug.Log(".. final scores loaded and set ");
    }
    
    //Load global highscores. Only neccessary after death
    private IEnumerator LoadGlobalScores(int limit) {
        Debug.Log("Loading global scores.. ");
        WWW globalScores = new WWW(globalScoresURL + limit.ToString());
        yield return globalScores;
        string globalScoresString = globalScores.text;
        List<string> rawScores = splitByString(globalScoresString, ";;;");
        foreach (string rawScore in rawScores) {
            result = new Dictionary<string, int>();
            result.Add(splitByString((splitByString((rawScore), "|||")[1]), ":::")[1], Int32.Parse(splitByString((splitByString((rawScore), "|||")[0]), ":::")[1]));
            globalGames.Add(result);
        }
        userdata.SetGlobalScores(globalGames);
        Debug.Log(".. global scores loaded and set ");
    }

    private List<string> splitByString(string stringToSplit, string splitter) {
        List<string> splittedStrings = new List<string>(stringToSplit.Split(new[] { splitter }, StringSplitOptions.RemoveEmptyEntries));
        return splittedStrings;
    }

    //This is meant for highscore to be found from loaded scores.
    private int LoadUserHighscore(List<Dictionary<string, int>> games) {
        Debug.Log("Loading " + userdata.GetUsername() + " highscore.. ");
        int maxScore = 0;
        for (int i = 0; i < games.Count; i++) {
            if (games[i].Values.ToArray()[0] > maxScore) {
                maxScore = games[i]["score"];
            }
        }
        return maxScore;
    }

    IEnumerator LoadUserHighScoreAtStart() {
        Debug.Log("Loading user " + userdata.GetUsername() +  " highscore.. ");
        //wait until there is a user defined in userdata script
        yield return new WaitUntil(() => !string.IsNullOrEmpty(userdata.GetUsername()));
        WWW userHighScore = new WWW(userScoresURL + userdata.GetUsername() + "&score_limit=1");
        yield return userHighScore;
        string userScoresString = userHighScore.text;
        int result = Int32.Parse(splitByString((splitByString((userScoresString), "|||")[0]), ":::")[1]);
        userdata.SetHighscore(result);
        
    }
}
