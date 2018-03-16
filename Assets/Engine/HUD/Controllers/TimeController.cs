using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {
    public UserData userData;
    private float timePlayed;
	// Use this for initialization
	void Start () {
        timePlayed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timePlayed += Time.deltaTime;
        print(timePlayed);
        userData.SetPlaytime(timePlayed);
	}
}
