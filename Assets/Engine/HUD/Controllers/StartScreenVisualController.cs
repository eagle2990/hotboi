using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class StartScreenVisualController : MonoBehaviour {
    public UserData userData;
    public GameObject menuLoginButton;
    public GameObject playButton;
    public GameObject loginForm;
    public GameObject loginWindow;
    public GameObject registerForm;
    public GameObject registerWindow;
    public GameObject registerScreenButton;
    //login form
    public Button loginButton;
    public InputField username;
    public InputField password;
    //reg form
    public InputField newUsername;
    public InputField newPassword;
    public InputField newRepeatPassword;
    public InputField newName;
    public DataInserter dataInserter;

    void Start () {
        userData.ResetLocalUserData();
        username.Select();
    }
	
	void Update () {
        if (gameObject.activeSelf) {
            if (userData.isLoggedIn) {
                menuLoginButton.GetComponentInChildren<TextMeshProUGUI>().text = "log out";
                playButton.GetComponentInChildren<TextMeshProUGUI>().text = "play as " + userData.GetUsername();
                ChangeButtonText(loginButton, "log out");

                loginForm.SetActive(false);
                registerScreenButton.SetActive(false);
                
            }
            if(!userData.isLoggedIn) {
                menuLoginButton.GetComponentInChildren<TextMeshProUGUI>().text = "log in";
                playButton.GetComponentInChildren<TextMeshProUGUI>().text = "play as guest";
                ChangeButtonText(loginButton, "log in");
                loginForm.SetActive(true);
                registerScreenButton.SetActive(true);
            }
            CheckShortcutKeys();
        }
    }

    public void RegisterUser() {
        if (newPassword.text == newRepeatPassword.text) {
            if (newUsername.text.Length < 8) {
                dataInserter.CreateUser(newName.text, newUsername.text, newPassword.text);
                ResetRegisterFields();
            } else {
                Debug.Log("Username max length is 8");
            }
        } else {
            Debug.Log("Passwords don't match!");
        }
    }

    private void ResetRegisterFields() {
        newName.text = null;
        newUsername.text = null;
        newPassword.text = null;
        newRepeatPassword.text = null;
    }



    void ChangeButtonText(Button button, string newText) {
        button.GetComponent<TextMeshProUGUI>().text = newText;
    }

    public void PlayGame() {
        SceneManager.LoadSceneAsync("Level1");
    }

    private void CheckShortcutKeys() {
        //make tab select other field
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (username.isFocused) {
                password.Select();
            }
            if (password.isFocused) {
                username.Select();
            }
            if (newUsername.isFocused) {
                newPassword.Select();
            }
            if (newPassword.isFocused) {
                newRepeatPassword.Select();
            }
            if (newRepeatPassword.isFocused) {
                newName.Select();
            }
            if (newName.isFocused) {
                newUsername.Select();
            }
        }
        //press enter to log in
        if (Input.GetKeyDown(KeyCode.Return)) {
            //if not logged in, return acts as "log in"
            if (!userData.isLoggedIn) {
                loginButton.GetComponent<Login>().LogInOut();
            }
            //if logged in, return acts as "play"
            if (userData.isLoggedIn) {
                PlayGame();
            }
        }
    }
    
}
