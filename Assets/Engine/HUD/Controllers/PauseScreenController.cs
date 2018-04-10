using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreenController : MonoBehaviour {
    public GameObject pauseScreen;
    public Button resumeButton;

    void Start () {
        //resumeButton.onClick.AddListener(ResumeGame);
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) {
            if (Time.timeScale != 0) {
                PauseGame();
            } else {
                ResumeGame();
            }

        }
    }

    private void ResumeGame() {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    private void PauseGame() {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }
}
