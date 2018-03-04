using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitHealth : MonoBehaviour
{
    public UnitBasicData BaseStats;
    public bool RestartHP;
    public float secondsTriggerCollision;
    public UnityEvent DamageEvent;
    public UnityEvent DeathEvent;

    int i = 0;

    void Start()
    {
        if (BaseStats.HP.Value <= 0 || RestartHP)
        {
            BaseStats.HP.SetValue(BaseStats.MaxHP.Value);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GotHitBy(other.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        StartCoroutine(DamagePerSecond(other.gameObject));
    }

    private void GotHitBy(GameObject other)
    {
        UnitBasicData otherObjectStats = GetUnitBasicData(other);
        CalculateDamage(otherObjectStats);
        CheckDeath();
    }

    private UnitBasicData GetUnitBasicData(GameObject other)
    {
        UnitHealth unitHealth = other.GetComponent<UnitHealth>() ?? other.GetComponentInParent<UnitHealth>();
        return unitHealth.BaseStats;
    }

    private UnitType GetCollidedUnitType(GameObject other)
    {
        UnitHealth unitHealth = other.GetComponent<UnitHealth>() ?? other.GetComponentInParent<UnitHealth>();
        if (unitHealth != null)
        {
            return unitHealth.BaseStats.Type;
        }
        return null;
    }

    private void CalculateDamage(UnitBasicData otherObjectStats)
    {
        if(otherObjectStats.Damage != null)
        {
            if (BaseStats.Type.IsInjuredBy(otherObjectStats.Type))
            {
                ApplyDamage(otherObjectStats.Damage);
            }
        }
    }

    private void CheckDeath()
    {
        if (BaseStats.HP.Value <= 0.0f)
        {
            gameObject.SetActive(false);
            DeathEvent.Invoke();
        }
    }

    private void ApplyDamage(FloatReference amount)
    {
        BaseStats.HP.Add(-amount);
        DamageEvent.Invoke();
    }

    private IEnumerator DamagePerSecond(GameObject other)
    {
        GotHitBy(other);
        yield return new WaitForSeconds(secondsTriggerCollision);
    }
}
