using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTimer : MonoBehaviour {

    public WeaponBasicData defaultWeapon;

    private GameObject burningMan;
    private Animator playerAnimator;
    private float doubleDamageTimer = 0f;
    private float slowEnemiesTimer = 0f;

    private void Start() {
        burningMan = FindPlayer()[0].transform.parent.Find("BurningMan").gameObject;
        if (burningMan.GetComponents<Animator>().Length > 1) {
            print("Too many animators on Sweetboi, Mikk. Tell Reimo that u broke everything :'(");
        }
        playerAnimator = burningMan.GetComponent<Animator>();
    }

    void Update () {
        if (doubleDamageTimer > 0) {
            doubleDamageTimer -= Time.deltaTime;
        }
        if (doubleDamageTimer <= 0) {
            doubleDamageTimer = 0;
            GetComponent<InflictDamage>().weaponStats = defaultWeapon;
            playerAnimator.SetBool("doubleDamage", false);
        }
        if (slowEnemiesTimer > 0) {
            slowEnemiesTimer -= Time.deltaTime;
        }
        if (slowEnemiesTimer <= 0) {
            slowEnemiesTimer = 0;
            playerAnimator.SetBool("slowEnemies", false);
        }
    }


    public void SetDoubleDamageTimer(float time) {
        playerAnimator.SetBool("doubleDamage", true);
        doubleDamageTimer += time;
    }

    public void SetSlowEnemiesTimer(float time) {
        playerAnimator.SetBool("slowEnemies", true);
        slowEnemiesTimer += time;
    }

    private GameObject[] FindPlayer() {
        return GameObject.FindGameObjectsWithTag("Player");
    }
}
