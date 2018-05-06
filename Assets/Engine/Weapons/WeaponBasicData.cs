using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponBasicData : ScriptableObject
{
    public string Name;
    public FloatReference CurrentDamage;
    public FloatReference InitialDamage;
    public FloatReference AttackSpeed;

    private void OnEnable()
    {
        if (InitialDamage == null)
        {
            InitialDamage = new FloatReference();
        }

        CurrentDamage = new FloatReference(InitialDamage.Value);
    }
}
