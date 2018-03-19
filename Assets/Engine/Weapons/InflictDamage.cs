using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InflictDamage : MonoBehaviour
{
    public WeaponBasicData weaponStats;
    public UnitBasicData weaponHolder;
    public UnityEvent attackEvent;

    private float attackCooldown;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Characters"))
        {
            if (attackCooldown < 0)
            {
                Hitting(other.gameObject);
                attackCooldown = 1.0f / weaponStats.AttackSpeed;
            }
            else
            {
                attackCooldown -= Time.deltaTime;
            }
        }
    }

    private void Hitting(GameObject other)
    {
        if (IsOtherUnitWeapon(other))
        {
            RecieveDamage component = GetRecieveDamageComponent(other);
            component.DamageCalculation(this);
            attackEvent.Invoke();
        }
    }

    private bool IsOtherUnitWeapon(GameObject other)
    {
        return gameObject != other && gameObject.transform.parent != other.transform && gameObject.transform.parent != other.transform.parent;
    }

    private RecieveDamage GetRecieveDamageComponent(GameObject other)
    {
        return other.GetComponent<RecieveDamage>() ?? other.GetComponentInParent<RecieveDamage>() ?? other.GetComponentInChildren<RecieveDamage>();
    }

    private bool IsNotAPlayer(GameObject other)
    {
        return other.CompareTag("Player");
    }
}
