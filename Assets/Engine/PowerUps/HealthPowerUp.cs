using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp: MonoBehaviour
{
    public PlayerBaseData playerStats;
    public float healingAmount = 5;
    public GameObject initialExplotion;
    public GameObject icon;
    public bool playerCanConsume;
    public bool enemiesCanConsume;

    public void Appear()
    {
        initialExplotion.SetActive(true);
        icon.SetActive(true);
    }

    public void Consumed()
    {
        float healedHP = playerStats.HP.Value + healingAmount;
        playerStats.HP.SetValue(healedHP > playerStats.MaxHP.Value ? playerStats.MaxHP.Value : healedHP);
    }

    public void Dissapear()
    {
        initialExplotion.SetActive(false);
        icon.SetActive(false);
    }
}
