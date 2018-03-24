using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class StartScreenVisualController : MonoBehaviour {
    public TextMeshProUGUI infoBoard;
    public UserData userData;
    public Button playButton;
    public GameObject loginForm;
    public GameObject startScreen;
    //login form
    public Button loginButton;
    public InputField username;
    public InputField password;
    //reg form
    public Button registerButton;
    public InputField newUsername;
    public InputField newPassword;
    public InputField newRepeatPassword;
    public InputField newName;

    public DataInserter dataInserter;
    private string textToBeShowIfLoggedIn;
    private string textToBeShowIfLoggedOut;
    private Login login;
    // Use this for initialization
    void Start () {
        userData.ResetLocalUserData();
        textToBeShowIfLoggedOut = "You're not logged in \n\nLogin to save your games.. \n..or don't";
        loginButton.onClick.AddListener(RefreshLogButton);
        playButton.onClick.AddListener(PlayGame);
        registerButton.onClick.AddListener(RegisterUser);
        username.Select();
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.activeSelf) {
		    textToBeShowIfLoggedIn = "Welcome " + userData.GetUsername() + ", \n\npress Play to start game";
            RefreshInfoBoard();
            if (userData.isLoggedIn) {
                ChangeButtonToLogOut();
            }
            if(!userData.isLoggedIn) {
                ChangeButtonToLogIn();
            }
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
                    RefreshLogButton();
                }
                //if logged in, return acts as "play"
                if (userData.isLoggedIn) {
                    PlayGame();
                }
            }
        }
    }

    //Change text on infoboard based on whether logged in or not
    void RefreshInfoBoard() {
        if (userData.isLoggedIn) {
            infoBoard.text = textToBeShowIfLoggedIn;
        }
        if (!userData.isLoggedIn) {
            infoBoard.text = textToBeShowIfLoggedOut;
        }
    }
    void RegisterUser() {
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
        button.GetComponentInChildren<Text>().text = newText;
    }

    void RefreshLogButton() {
        login = gameObject.GetComponent<Login>();
        if (userData.isLoggedIn) {
            login.LogOut();
            //username.text = null;
            password.text = null;
            ChangeButtonToLogIn();
        }
        if (!userData.isLoggedIn) {
            userData.SetUsername(username.text);
            userData.password = password.text;
            login.LogIn();
            if (userData.isLoggedIn) {
                ChangeButtonToLogOut();
            }
        }
    }

    private void ChangeButtonToLogOut() {
        //Change button text to "Log out" so that same button can be used for loggin out
        ChangeButtonText(loginButton, "Log out");
        loginForm.gameObject.SetActive(false);

    }

    private void ChangeButtonToLogIn() {
        ChangeButtonText(loginButton, "Log in");
        //enable form
        loginForm.gameObject.SetActive(true);
    }
    public void PlayGame() {
        SceneManager.LoadSceneAsync(0);
    }

    
}
