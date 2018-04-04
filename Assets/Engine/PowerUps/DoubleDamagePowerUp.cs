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
    //public bool playerCanConsume;
    //public bool enemiesCanConsume;

    private WeaponBasicData weaponStats;

    public void Appear() {
        initialExplotion.SetActive(true);
        icon.SetActive(true);
    }

    public void Consumed() {
        //TODO change enemy attack
    }

    public void Dissapear() {
        initialExplotion.SetActive(false);
        icon.SetActive(false);
    }

    public void DoDamage() {
  
    }
}
