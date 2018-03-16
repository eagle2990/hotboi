using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UserData : ScriptableObject {
    public string username;
    public string password;
    public int highscore;
    public bool isLoggedIn;
    public List<Dictionary<string, int>> scores = new List<Dictionary<string, int>>();
    public List<Dictionary<string, int>> globalScores = new List<Dictionary<string, int>>();
    public Dictionary<string, string> achievements = new Dictionary<string, string>();
    public int mostKills;
    public int highestLevelReached;
    public FloatVariable score;
    public FloatVariable kills;
    public FloatVariable playtime;
    public FloatVariable level;

    public void SetPlaytime(float playtime) {
        this.playtime.Value = playtime;
    }
    public FloatVariable GetPlaytime() {
        return playtime;
    }
    public void SetKills(float kills) {
        this.kills.Value = kills;
    }
    public FloatVariable GetKills() {
        return kills;
    }

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
    public void ResetLocalScores() {
        this.scores.Clear();
    }
    public void ResetGlobalScores() {
        this.globalScores.Clear();
    }
    public void AddAchievement(string title, string description) {
        this.achievements.Add(title, description);
    }
    public void ResetLocalAchievements() {
        this.achievements.Clear();
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
    public void ResetLocalUserData() {
        isLoggedIn = false;
        ResetGlobalScores(); //reset global scores
        ResetLocalAchievements();
        ResetLocalScores();
        SetHighestLevelReached(0);
        SetHighscore(0);
        SetMostKills(0);
        score.SetValue(0);
        level.SetValue(0);
        playtime.SetValue(0);
        kills.SetValue(0);
    }
}
