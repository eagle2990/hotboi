using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfLoggedInDisableButton : MonoBehaviour {

    public UserData userData;

    void Update () {
        if (gameObject.transform.parent == enabled && userData.isLoggedIn == true) {
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);
        }
	}
}
