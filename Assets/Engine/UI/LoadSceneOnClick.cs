using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadByIndex(int sceneIndex) 
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(sceneIndex);
    }
    public void LoadByName(string name) {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(name);
    }
}
