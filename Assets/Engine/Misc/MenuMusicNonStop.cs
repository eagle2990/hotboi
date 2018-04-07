using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicNonStop : MonoBehaviour {

    static bool AudioBegin = false;
    void Awake() {
        if (!AudioBegin) {
            GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }
    void Update() {
        //if (Application.loadedLevelName == "Upgraded") {
        //    GetComponent<AudioSource>().Stop();
        //    AudioBegin = false;
        //}
    }

}
