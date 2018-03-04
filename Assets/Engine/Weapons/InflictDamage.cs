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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Characters"))
        {
            Hitting(other.gameObject);
        }
    }

    //private IEnumerator OnTriggerStay(Collider other)
    //{
    //    yield return new WaitForSeconds(10);
    //    Hitting(other.gameObject);
    //}

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
