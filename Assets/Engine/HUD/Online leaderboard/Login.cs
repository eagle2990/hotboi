using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour {
    public UserData userData;
    public DataLoader dataloader;
    public GameObject loginForm;

    private string LoginURL = "http://hotboi.veeb.eu/php/login.php";
    private InputField username;
    private InputField password;

    private string textToBeShowIfLoggedIn;
    private string textToBeShowIfLoggedOut;

    private void Start() {
        username = loginForm.transform.Find("Username").GetComponent<InputField>();
        password = loginForm.transform.Find("Password").GetComponent<InputField>();
    }

    private void LogIn() {
        StartCoroutine(LoginToDB(username.text, password.text));
    }
    private void LogOut() {
        userData.ResetLocalUserData(); //log out by resetting data
        password.text = "";
    }

    public void LogInOut() {
        if (!userData.isLoggedIn) {
            LogIn();
        } else {
            LogOut();
        }
    }
    
    IEnumerator LoginToDB(string username, string password) {
        WWWForm form = new WWWForm();
        print("user: " + username + " pass " + password);
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);
        WWW www = new WWW(LoginURL, form); 
        yield return www;
        string result = www.text;
        if (result.ToLower().Trim() == "success") {
            userData.isLoggedIn = true;
            userData.SetUsername(username);
            Debug.Log("Login success ");
            dataloader.LoadStartingData();
        } else {
            Debug.Log("Could not log in ");
        }
    }

    void ChangeButtonText(Button button, string newText) {
        button.GetComponent<TextMeshProUGUI>().text = newText;
    }
}
