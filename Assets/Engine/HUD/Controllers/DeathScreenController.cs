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
    private DataLoader dataLoader;
    public FloatVariable SweetboiHP;
    public PlayerBaseData SweetboiStats;
    
    // Use this for initialization
	void Start () {
        playAgainButton.onClick.AddListener(PlayAgain);
        dataLoader = gameObject.GetComponent<DataLoader>();
	}
	
	// Update is called once per frame
	void Update () {
        if (deathScreen.activeSelf == true && Input.GetKeyDown(KeyCode.R)) {
            PlayAgain();
        }
    }

    public void ShowDeathScreen() {
        
        //dataLoader.LoadScores(10);
        //ShowUserScores();
        dataLoader.LoadGlobalData();
        if (!userData.isLoggedIn) {
            ShowGlobalScores();
        } else {
            print("private data loaded");
            //dataLoader.LoadPrivateData();
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

        string ScoreFieldText = "";
        List<Dictionary<string, int>> globalGames = userData.GetGlobalScores();
        for (int i = 0; i < globalGames.Count; i++) {
            //ScoreFieldText += i + 1 + ": " + globalGames[i]["score"] + "\n";
            foreach (KeyValuePair<string, int> kvp in globalGames[i]) {
                //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
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
        //userData.
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        
    }

}
