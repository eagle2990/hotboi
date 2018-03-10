using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInserter : MonoBehaviour {

    public string inputName;
    public string inputUsername;
    public string inputPassword;
    string CreateUserURL = "https://sweetboi.000webhostapp.com/InsertUser.php";
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            CreateUser(inputName, inputUsername, inputPassword);
        }
    }

    public void CreateUser(string name, string username, string password) {
        WWWForm form = new WWWForm();
        form.AddField("namePost", name);
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);

        WWW www = new WWW(CreateUserURL, form);
    }
}
