﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RecieveDamage : MonoBehaviour
{
    public UnitBasicData UnitStats;
    public bool RestartHP;
    public Image HealthBar;

    public UnityEvent DamageEvent;
    public UnityEvent DeathEvent;
    

    private void Start()
    {
        if (UnitStats.HP.Value <= 0 || RestartHP)
        {
            UnitStats.HP.SetValue(UnitStats.MaxHP.Value);
        }
    }

    public void DamageCalculation(InflictDamage receivedDamage)
    {
        if (IsAnOppositeType(receivedDamage.weaponHolder.Type))
        {
            ApplyDamage(receivedDamage.weaponStats);
            UpdateHealthBar();
            CheckDeath();
        }
    }

    private void UpdateHealthBar()
    {
        if (HealthBar != null)
        {
            HealthBar.fillAmount = UnitStats.HP.Value / UnitStats.MaxHP.Value;
        }
    }

    private void CheckDeath()
    {
        if (UnitStats.HP.Value <= 0.0f)
        {
            DeathEvent.Invoke();
            SetToDefaultLayer();
        }
    }

    private void ApplyDamage(WeaponBasicData weaponStats)
    {
        UnitStats.HP.Add(-weaponStats.Damage);
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
        } else
        {
            gameObject.SetActive(false);
        }
    }

    private void SetToDefaultLayer()
    {
        gameObject.layer = 0;
    }
}