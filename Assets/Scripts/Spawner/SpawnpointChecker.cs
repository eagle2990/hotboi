using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointChecker : MonoBehaviour {
    public bool isVisible = true;

    void OnBecameVisible() {
        isVisible = true;
    }

    void OnBecameInvisible() {
        //print("became invisible");
        isVisible = false;
    }
}
