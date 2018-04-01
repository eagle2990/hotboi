using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaKillPowerUp : MonoBehaviour {

    public PlayerBaseData playerStats;
    public float killRadius = 10f;
    public GameObject initialExplosion;
    public GameObject icon;
    //public bool playerCanConsume;
    //public bool enemiesCanConsume;

    public void Appear() {
        initialExplosion.SetActive(true);
        icon.SetActive(true);
    }

    public void Consumed() {
        
    }

    public void Dissapear() {
        initialExplosion.SetActive(false);
        icon.SetActive(false);
    }
}
