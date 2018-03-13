using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour {
    public UserData userdata;
    public DataLoader dataloader;
    //public string inputUsername;
    //public string inputPassword;

    string LoginURL = "https://localhost/sweetboi/Login.php";

    // Use this for initialization
    void Start () {
		 
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.L)) {
            StartCoroutine(LoginToDB(userdata.getUsername(), userdata.password));
        }
    }
    IEnumerator LoginToDB(string username, string password) {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);
        WWW www = new WWW(LoginURL, form); 
        yield return www;
        string result = www.text;
        if (result.ToLower().Trim() == "success".ToLower()) {
            userdata.setUsername(username);
            print("Login success ");
            dataloader.LoadData();
        }
    }
}
