using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerBaseData : UnitBasicData
{
    public FloatVariable HP;

    private void OnEnable()
    {
        if (HP == null)
        {
            HP = CreateInstance<FloatVariable>();
        }
        HP.SetValue(MaxHP);
    }
}
