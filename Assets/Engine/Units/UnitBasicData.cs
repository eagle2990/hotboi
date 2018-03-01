using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitBasicData : ScriptableObject
{
    public string Name = "Unit";
    public FloatReference MaxHP;
    public FloatReference MoveSpeed;
    public FloatReference RotationSpeed;
    public FloatVariable HP;
    public FloatReference Damage;
    public UnitType Type;
}
