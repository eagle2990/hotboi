using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreenController : MonoBehaviour {
    public GameObject pauseScreen;
    public Button resumeButton;
	// Use this for initialization
	void Start () {
        resumeButton.onClick.AddListener(ResumeGame);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P)) {
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
