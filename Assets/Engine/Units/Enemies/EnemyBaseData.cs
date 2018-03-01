using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyBaseData : UnitBasicData
{

    private void OnEnable()
    {
        if (HP == null)
        {
            HP = new FloatVariable();
        }
    }
}
