using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitBase : ScriptableObject
{
    public string Name = "Unit";
    public FloatReference MaxHP;
    public FloatReference MoveSpeed;
    public FloatVariable HP;
}
