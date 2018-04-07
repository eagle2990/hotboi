using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemiesPowerUp : MonoBehaviour {

    [Range(0.1f, 1f)]
    public float enemySpeedMultiplier = 0.5f;
    [Range(1f, 20f)]
    public float effectTimer = 10f;

    public void Appear() {
    }

    public void Consumed() {
        //TODO make enemies slow
        //set timer to given time
        GameObject.FindGameObjectsWithTag("Player")[0].transform.parent.gameObject.GetComponentInChildren<WeaponTimer>().SetSlowEnemiesTimer(effectTimer);
    }

    public void Disappear() {
    }
    private GameObject[] FindPlayer() {
        return GameObject.FindGameObjectsWithTag("Player");
    }
}
