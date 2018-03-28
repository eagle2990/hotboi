using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerBaseData : UnitBasicData
{
    public FloatReference SprintSpeed;
    public FloatReference MaxSprintAmount;
    public FloatVariable SprintAmount;
    public FloatVariable HP;

    private void OnEnable()
    {
        if (HP == null)
        {
            HP = CreateInstance<FloatVariable>();
        }
        HP.SetValue(MaxHP);

         if (SprintAmount == null)
        {
            SprintAmount = CreateInstance<FloatVariable>();
        }
        SprintAmount.SetValue(MaxSprintAmount);
    }
}
