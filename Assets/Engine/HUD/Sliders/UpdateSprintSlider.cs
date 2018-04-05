using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSprintSlider : MonoBehaviour {

    public FloatVariable playerSprintAmount;
    public float sprintDepletionMultiplier;
    public float sprintRechargeMultiplier;
    public PlayerBaseData playerStats;
    public float timer;

    private Slider slider;
    private float previousValue;
    private Color origColor;

    void Start() {
        timer = 0f;
        sprintDepletionMultiplier = 28f;
        sprintRechargeMultiplier = 10f;
        playerSprintAmount.Value = playerStats.MaxSprintAmount.Value;
        slider = GetComponent<Slider>();
        origColor = slider.GetComponentInChildren<Image>().color;
        slider.GetComponentInChildren<FlashSprintBar>().enabled = false;
        slider.maxValue = playerStats.MaxSprintAmount;

    }

    void Update() {
        if (timer > 0) {
            timer -= Time.deltaTime;
            slider.GetComponentInChildren<FlashSprintBar>().enabled = true;
        } else {
            slider.GetComponentInChildren<Image>().color = slider.GetComponentInChildren<FlashSprintBar>().GetOriginalColor();
            slider.GetComponentInChildren<FlashSprintBar>().enabled = false;
        }
        if (playerSprintAmount.Value != previousValue) {
            slider.value = playerSprintAmount.Value;
            previousValue = playerSprintAmount.Value;
        }
        if (Input.GetKey(KeyCode.LeftShift) && playerSprintAmount.Value > 0) {
            if (timer <= 0) {
                playerSprintAmount.Value -= Time.deltaTime * sprintDepletionMultiplier;
            }
        }
        else if (playerSprintAmount.Value < playerStats.MaxSprintAmount && !Input.GetKey(KeyCode.LeftShift)) {
            playerSprintAmount.Value += Time.deltaTime * sprintRechargeMultiplier;

        }
    }
}
