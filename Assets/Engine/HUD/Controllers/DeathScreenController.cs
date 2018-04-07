using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreenController : MonoBehaviour {

    public GameObject deathScreen;
    public TextMeshProUGUI scoreTable;
    public Button playAgainButton;
    public UserData userData;
    public FloatVariable SweetboiHP;
    public PlayerBaseData SweetboiStats;
    public TextMeshProUGUI latestScore;
   

	void Start () {
        playAgainButton.onClick.AddListener(PlayAgain);
	}
	
	void Update () {
        if (deathScreen.activeSelf == true && Input.GetKeyDown(KeyCode.R)) {
            PlayAgain();
        }
    }

    public void ShowDeathScreen() {
        if (!userData.isLoggedIn) {
            ShowGlobalScores();
        } else {
            ShowUserScores();
        }
        deathScreen.SetActive(true);
    }

    public void HideDeathScreen() {
        deathScreen.SetActive(false);
    }

    public void ShowUserScores() {
        string ScoreFieldText = "";
        List<Dictionary<string, int>> games = userData.GetScores();
        for (int i = 0; i < games.Count; i++) {
                 ScoreFieldText += i+1 + ". " + userData.GetUsername() + ": " + games[i]["score"] + "\n";
        }
        scoreTable.SetText(ScoreFieldText);
    }

    public void ShowGlobalScores() {
        StartCoroutine(GlobalScoreLoader());
    }
    private IEnumerator GlobalScoreLoader() {
        string ScoreFieldText = "";
        List<Dictionary<string, int>> globalGames = userData.GetGlobalScores();
        yield return new WaitUntil(() => globalGames != null);
        for (int i = 0; i < globalGames.Count; i++) {
            foreach (KeyValuePair<string, int> kvp in globalGames[i]) {
                ScoreFieldText += string.Format(i+1 + ". " + "{0}: {1}", kvp.Key, kvp.Value + "\n");
            }
        }
        scoreTable.SetText(ScoreFieldText);

    }

    private void ResetPlayerHealth() {
        SweetboiHP.Value = SweetboiStats.MaxHP.Value;
        SweetboiStats.HP.Value = SweetboiStats.MaxHP.Value;
    }

    private void PlayAgain() {
        ResetPlayerHealth();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
