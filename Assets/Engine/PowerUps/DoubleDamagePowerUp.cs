using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamagePowerUp : MonoBehaviour {
    public PlayerBaseData playerStats;
    [Range(5f, 30f)]
    public float damageDuration = 10f;
    public float damageMultiplier = 2f;
    public GameObject initialExplotion;
    public GameObject icon;
    public Color movingFireColor; 
    public Color sparksColor;
    public Color baseFireColor;
    public Color smokeColor;
    public Color fireLightColor;
    public GameObject movingFire;
    public GameObject sparks;
    public GameObject baseFire;
    public GameObject smoke;
    public GameObject fireLight;
    //public bool playerCanConsume;
    //public bool enemiesCanConsume;

    private WeaponBasicData weaponStats;

    public void Appear() {
        initialExplotion.SetActive(true);
        icon.SetActive(true);
    }

    public void Consumed() {
        //TODO change particle system light + point light color to white

        movingFire.GetComponent<ParticleSystem>().startColor = movingFireColor;
        sparks.GetComponent<ParticleSystem>().startColor = sparksColor;
        baseFire.GetComponent<ParticleSystem>().startColor = baseFireColor;
        smoke.GetComponent<ParticleSystem>().startColor = smokeColor;
        fireLight.GetComponent<FlickeringLight>().originalColor = fireLightColor;
        //TODO change enemy attack
    }

    public void Dissapear() {
        initialExplotion.SetActive(false);
        icon.SetActive(false);
    }

    private GameObject[] FindPlayer() {
        return GameObject.FindGameObjectsWithTag("Player");
    }
}
