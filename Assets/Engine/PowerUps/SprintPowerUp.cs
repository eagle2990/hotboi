using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintPowerUp : MonoBehaviour {
    public PlayerBaseData playerStats;
    public float sprintAddAmount = 35;
    public GameObject initialExplotion;
    public GameObject icon;

    public void Appear() {
        initialExplotion.SetActive(true);
        icon.SetActive(true);
    }

    public void Consumed() {
        float addedSprintAmount = playerStats.SprintAmount.Value + sprintAddAmount;
        playerStats.SprintAmount.SetValue(addedSprintAmount > playerStats.MaxSprintAmount.Value ? playerStats.MaxSprintAmount.Value : addedSprintAmount);
    }

    public void Dissapear() {
        initialExplotion.SetActive(false);
        icon.SetActive(false);
    }
}
