using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class StartScreenVisualController : MonoBehaviour {
    public TextMeshProUGUI infoBoard;
    public UserData userData;
    public Button loginButton;
    public Button playButton;
    public GameObject loginForm;
    public GameObject startScreen;
    public InputField username;
    public InputField password;
    private string textToBeShowIfLoggedIn;
    private string textToBeShowIfLoggedOut;
    private Login login;
    // Use this for initialization
    void Start () {
        Time.timeScale = 0;
        userData.ResetLocalUserData();
        textToBeShowIfLoggedOut = "You're not logged in \n\nLogin to save your games.. \n..or don't";
        loginButton.onClick.AddListener(RefreshLogButton);
        playButton.onClick.AddListener(PlayGame);
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
            }
            //press enter to log in
            if (Input.GetKeyDown(KeyCode.Return)) {
                //if logged in, disable using enter to log out
                if (!userData.isLoggedIn) {
                    RefreshLogButton();
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
        startScreen.SetActive(false);
        Time.timeScale = 1;
    }

    
}
