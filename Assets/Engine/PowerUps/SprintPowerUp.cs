using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintPowerUp : MonoBehaviour {

    public PlayerBaseData playerStats;
    public float sprintDuration = 5f;
    public float sprintAddAmount = 5f;
    public GameObject sprintBar;
    public bool sprintPowerUpByAddition;

    private UpdateSprintSlider sprintSliderScript;

    private void Start() {
        sprintSliderScript = sprintBar.transform.GetChild(0).GetComponent<UpdateSprintSlider>();
    }

    public void Appear() {
    }

    public void Consumed() {
        if (!sprintPowerUpByAddition) {
            sprintSliderScript.timer = sprintDuration;
            playerStats.SprintAmount.SetValue(playerStats.MaxSprintAmount.Value);
        } else {
            float addedSprintAmount = playerStats.SprintAmount.Value + sprintAddAmount;
            playerStats.SprintAmount.SetValue(addedSprintAmount > playerStats.MaxSprintAmount.Value ? playerStats.MaxSprintAmount.Value : addedSprintAmount);
        }
    }

    public void Dissapear() {
    }
}
