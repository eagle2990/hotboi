using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponBasicData : ScriptableObject
{
    public string Name;
    public FloatReference Damage;
    public FloatReference AttackSpeed;
}
