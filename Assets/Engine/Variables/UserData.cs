using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UserData : ScriptableObject {
    public string username;
    public string password;
    public int highscore;
    public List<int> scores;
    public Dictionary<string, string> achievements;
    public int mostKills;
    public int highestLevelReached;
    public FloatVariable score;
    public FloatVariable kills;
    public FloatVariable playtime;
    public FloatVariable level;

    public void setUsername(string username) {
        this.username = username;
    }
    public string getUsername() {
        return this.username;
    }
    public void setHighscore(int highscore) {
        this.highscore = highscore;
    }
    public int getHighscore() {
        return this.highscore;
    }
    public void addAchievement(string title, string description) {
        this.achievements.Add(title, description);
    }
    public Dictionary<string, string> getAchievements() {
        return achievements;
    }
    public void setMostKills(int kills) {
        this.mostKills = kills;
    }
    public int getMostKills() {
        return this.mostKills;
    }
    public void setHighestLevelReached(int levelReached) {
        this.highestLevelReached = levelReached;
    }
    public int getHighestLevelReached() {
        return this.highestLevelReached;
    }
}
