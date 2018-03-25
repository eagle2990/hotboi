using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RecieveDamage : MonoBehaviour
{
    public UnitBasicData UnitStats;
    private float currentHP;
    private PlayerBaseData PlayerData;
    public bool isUsingExternalHPVariable;
    public Image HealthBar;

    public UnityEvent DamageEvent;
    public UnityEvent DeathEvent;

    private void Start()
    {
        if (isUsingExternalHPVariable)
        {
            PlayerData = (PlayerBaseData)UnitStats;
        }
        else
        {
            currentHP = UnitStats.MaxHP.Value;
        }
    }

    public void DamageCalculation(InflictDamage receivedDamage)
    {
        if (IsAnOppositeType(receivedDamage.weaponHolder.Type))
        {
            ApplyDamage(receivedDamage.weaponStats);
            CheckDeath();
        }
    }

    private void UpdateHealthBar()
    {
        float hp = isUsingExternalHPVariable ? PlayerData.HP.Value : currentHP;
        if (HealthBar != null)
        {
            HealthBar.fillAmount = hp / UnitStats.MaxHP.Value;
            if (hp <= 0f) 
            {
                HealthBar.gameObject.transform.parent.parent.gameObject.SetActive(false);
            }
        }
    }

    private void CheckDeath()
    {
        float hp = isUsingExternalHPVariable ? PlayerData.HP.Value : currentHP;
        if (hp <= 0.0f)
        {
            DeathEvent.Invoke();
            SetToDefaultLayer();
        }
    }

    private void ApplyDamage(WeaponBasicData weaponStats)
    {
        if (isUsingExternalHPVariable)
        {
            PlayerData.HP.Add(-weaponStats.Damage);
        }
        else
        {
            currentHP -= weaponStats.Damage;
        }
        UpdateHealthBar();
        DamageEvent.Invoke();
    }

    private bool IsAnOppositeType(UnitType type)
    {
        return UnitStats.Type.IsInjuredBy(type);
    }

    private void DeactivateParentOrSelf()
    {
        if (gameObject.transform.parent != null)
        {
            gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void SetToDefaultLayer()
    {
        gameObject.layer = 0;
    }
}
