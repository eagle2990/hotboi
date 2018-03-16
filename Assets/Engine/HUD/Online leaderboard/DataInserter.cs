using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInserter : MonoBehaviour {

    public UserData userdata;
    private string inputName;
    private string inputUsername;
    private string inputPassword;
    private int inputScore;
    private int inputKills;
    private float inputPlaytime;
    private int inputLevels;
    private string CreateUserURL = "https://sweetboi.000webhostapp.com/insert_user.php";
    private string InsertGameResultURL = "https://sweetboi.000webhostapp.com/insert_game_result.php";
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            //Test user creation
        }
    }
    public void Register() {
        Debug.Log("Make a user registration form");
            //CreateUser(inputName, inputUsername, inputPassword);

    }

    public void UploadResultToDB() {
        UploadResult(userdata.GetUsername(),
                userdata.password, (int)userdata.score.Value,
                (int)userdata.GetKills().Value, (int)userdata.GetPlaytime().Value, (int)userdata.level.Value);
    }

    private void CreateUser(string name, string username, string password) {
        WWWForm form = new WWWForm();
        form.AddField("namePost", name);
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);
        WWW www = new WWW(CreateUserURL, form);
    }

    private void UploadResult(string username, string password, int score, int kills, int playtime, int level) {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);
        form.AddField("scorePost", score);
        form.AddField("killsPost", kills);
        form.AddField("playtimePost", playtime);
        form.AddField("levelPost", level);
        WWW www = new WWW(InsertGameResultURL, form);
    }
}
