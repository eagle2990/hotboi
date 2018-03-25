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
    // Use this for initialization
    void Start() {
        sprintDepletionMultiplier = 28f;
        sprintRechargeMultiplier = 10f;
        playerSprintAmount.Value = playerStats.MaxSprintAmount.Value;
        slider = GetComponent<Slider>();
        slider.maxValue = playerStats.MaxSprintAmount;
    }

    // Update is called once per frame
    void Update() {
        if (playerSprintAmount.Value != previousValue) {
            slider.value = playerSprintAmount.Value;
            previousValue = playerSprintAmount.Value;
        }
        if (Input.GetKey(KeyCode.LeftShift) && playerSprintAmount.Value > 0) {
            playerSprintAmount.Value -= Time.deltaTime * sprintDepletionMultiplier;

        }
        else if (playerSprintAmount.Value < playerStats.MaxSprintAmount && !Input.GetKey(KeyCode.LeftShift)) {
            playerSprintAmount.Value += Time.deltaTime * sprintRechargeMultiplier;
            print(sprintRechargeMultiplier);

        }
    }
}
