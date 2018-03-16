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
        userData.ResetLocalUserData();
        textToBeShowIfLoggedOut = "You're not logged in \n\nLogin to save your games.. \n..or don't";
        loginButton.onClick.AddListener(RefreshLogButton);
        Time.timeScale = 0;
        playButton.onClick.AddListener(PlayGame);
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.activeSelf) {
		    textToBeShowIfLoggedIn = "Welcome " + userData.GetUsername() + ", \n\npress Play to start game";
            RefreshInfoBoard();
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
        if (!userData.isLoggedIn) {
            userData.SetUsername(username.text);
            userData.password = password.text;
            login.LogIn();
            ChangeButtonToLogOut();
        }
        if (userData.isLoggedIn) {

            login.LogOut();
            ChangeButtonToLogIn();
        }
    }

    private void ChangeButtonToLogOut() {
        //Change button text to "Log out" so that same button can be used for loggin out
        ChangeButtonText(loginButton, "Log out");
        loginForm.gameObject.SetActive(false);

    }

    private void ChangeButtonToLogIn() {
        ChangeButtonText(loginButton, "Log in");
        //remove form
        loginForm.gameObject.SetActive(true);
    }
    public void PlayGame() {
        startScreen.SetActive(false);
        Time.timeScale = 1;
    }

    
}
