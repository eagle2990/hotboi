using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealthSlider : MonoBehaviour
{
    public FloatVariable playerHealth;
    private Slider slider;
    private float previousValue;
    public UnitBasicData playerStats;
    // Use this for initialization
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = playerStats.MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.Value != previousValue)
        {
            slider.value = playerHealth.Value;
            previousValue = playerHealth.Value;
        }
    }
}
