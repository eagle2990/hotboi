using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InflictDamage : MonoBehaviour
{
    public WeaponBasicData weaponStats;
    public UnitBasicData weaponHolder;
    public UnityEvent inflictingDamageEvent;

    private void OnTriggerEnter(Collider other)
    {
        Hitting(other.gameObject);
    }

    private void Hitting(GameObject gameObject)
    {
        //UnitType otherType = ga
    }
}
