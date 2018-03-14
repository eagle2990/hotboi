using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UserData : ScriptableObject {
    public string username;
    public string password;
    public int highscore;
    public List<Dictionary<string, int>> scores = new List<Dictionary<string, int>>();
    public List<Dictionary<string, int>> globalScores = new List<Dictionary<string, int>>();
    public Dictionary<string, string> achievements;
    public int mostKills;
    public int highestLevelReached;
    public FloatVariable score;
    public FloatVariable kills;
    public FloatVariable playtime;
    public FloatVariable level;

    public void SetUsername(string username) {
        this.username = username;
    }
    public string GetUsername() {
        return this.username;
    }
    public void SetHighscore(int highscore) {
        this.highscore = highscore;
    }
    public int GetHighscore() {
        return this.highscore;
    }
    public void AddAchievement(string title, string description) {
        this.achievements.Add(title, description);
    }
    public Dictionary<string, string> getAchievements() {
        return achievements;
    }
    public void SetMostKills(int kills) {
        this.mostKills = kills;
    }
    public void SetScores(List<Dictionary<string, int>> scores) {
        this.scores = scores;
    }
    public List<Dictionary<string, int>> GetScores() {
        return scores;
    }
    public void SetGlobalScores(List<Dictionary<string, int>> globalScores) {
        this.globalScores = globalScores;
    }
    public List<Dictionary<string, int>> GetGlobalScores() {
        return this.globalScores;
    }
    public int GetMostKills() {
        return this.mostKills;
    }
    public void SetHighestLevelReached(int levelReached) {
        this.highestLevelReached = levelReached;
    }
    public int GetHighestLevelReached() {
        return this.highestLevelReached;
    }
}
