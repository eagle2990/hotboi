﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInserter : MonoBehaviour {
    public DataLoader dataLoader;
    public UserData userdata;
    private int inputScore;
    private int inputKills;
    private float inputPlaytime;
    private int inputLevels;
    private string CreateUserURL = "https://sweetboi.000webhostapp.com/insert_user.php";
    private string InsertGameResultURL = "https://sweetboi.000webhostapp.com/insert_game_result.php";

    public void UploadResultToDB() {
        StartCoroutine(UploadResult(userdata.GetUsername(),
                userdata.password, (int)userdata.score.Value,
                (int)userdata.GetKills().Value, (int)userdata.GetPlaytime().Value, (int)userdata.level.Value));
    }

    public void CreateUser(string name, string username, string password) {
        WWWForm form = new WWWForm();
        form.AddField("namePost", name);
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);
        WWW www = new WWW(CreateUserURL, form);
        //TODO check if user with same username already exists
        print("Maybe registered new user: " + username);
    }

    IEnumerator UploadResult(string username, string password, int score, int kills, int playtime, int level) {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);
        form.AddField("scorePost", score);
        form.AddField("killsPost", kills);
        form.AddField("playtimePost", playtime);
        form.AddField("levelPost", level);
        WWW www = new WWW(InsertGameResultURL, form);
        yield return www;
        print("Upload result: " + www.text);
        if (www.text == "everything ok") {
            dataLoader.LoadPrivateData();
        }
    }
}
