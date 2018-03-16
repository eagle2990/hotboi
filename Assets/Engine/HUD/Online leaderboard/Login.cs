using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour {
    public UserData userdata;
    public DataLoader dataloader;
    string LoginURL = "https://sweetboi.000webhostapp.com/login.php";

    public void LogIn() {
        StartCoroutine(LoginToDB(userdata.GetUsername(), userdata.password));
    }
    public void LogOut() {
        userdata.ResetLocalUserData(); //log out and reset data
    }
    
    IEnumerator LoginToDB(string username, string password) {
        WWWForm form = new WWWForm();
        print("user: " + username + " pass " + password);
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);
        WWW www = new WWW(LoginURL, form); 
        yield return www;
        string result = www.text;
        if (result.ToLower().Trim() == "success".ToLower()) {
            userdata.isLoggedIn = true;
            userdata.SetUsername(username);
            Debug.Log("Login success ");
            dataloader.LoadData();
        } else {
            Debug.Log("Could not log in ");
        }
    }
}
