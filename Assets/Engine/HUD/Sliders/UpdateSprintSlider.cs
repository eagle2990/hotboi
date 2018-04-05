using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSprintSlider : MonoBehaviour {
    public FloatVariable playerSprintAmount;
    private Slider slider;
    public float sprintDepletionMultiplier;
    public float sprintRechargeMultiplier;
    private float previousValue;
    public PlayerBaseData playerStats;
    public bool hasSprintPowerUp;
    public float timer = 0f;

    void Start() {
        sprintDepletionMultiplier = 28f;
        sprintRechargeMultiplier = 10f;
        playerSprintAmount.Value = playerStats.MaxSprintAmount.Value;
        slider = GetComponent<Slider>();
        slider.maxValue = playerStats.MaxSprintAmount;
    }

    void Update() {
        if (playerSprintAmount.Value != previousValue) {
            slider.value = playerSprintAmount.Value;
            previousValue = playerSprintAmount.Value;
        }

        if (Input.GetKey(KeyCode.LeftShift) && playerSprintAmount.Value > 0) {
            if (timer <= 0) {
                playerSprintAmount.Value -= Time.deltaTime * sprintDepletionMultiplier;
            } else {
                timer -= Time.deltaTime;
            }

        }
        else if (playerSprintAmount.Value < playerStats.MaxSprintAmount && !Input.GetKey(KeyCode.LeftShift)) {
            playerSprintAmount.Value += Time.deltaTime * sprintRechargeMultiplier;

        }
    }
}
