using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour {

    public GameObject[] onObjectsEnabledCursorEnable;

    private void Update() {
        bool hasActiveObjects = false;
        foreach (GameObject go in onObjectsEnabledCursorEnable) {
            if (go.activeSelf) {
                hasActiveObjects = true;
            }
        }
        Cursor.visible = hasActiveObjects;
    }
}
