using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour {
    public UserData userdata;
    public DataLoader dataloader;
    public TextMeshProUGUI infoBoard;
    //public string inputUsername;
    //public string inputPassword;
    public Text buttonText;
    string LoginURL = "https://localhost/sweetboi/Login.php";

    // Use this for initialization
    void Start () {
		 
	}
	
	// Update is called once per frame
	void Update () {
    }
    public void LogIn() {
        StartCoroutine(LoginToDB(userdata.GetUsername(), userdata.password));
    }
    public void changeToLogOut() {
        buttonText.text = "Log out";
        infoBoard.text = "Sweeeeet....boi?";
    }

    IEnumerator LoginToDB(string username, string password) {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);
        WWW www = new WWW(LoginURL, form); 
        yield return www;
        string result = www.text;
        if (result.ToLower().Trim() == "success".ToLower()) {
            userdata.SetUsername(username);
            Debug.Log("Login success ");
            dataloader.LoadData();
        }
    }
}
