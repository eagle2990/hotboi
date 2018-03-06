using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyBaseData : UnitBasicData
{
    public FloatVariable scoringPoints;

    private void OnEnable()
    {
        if (HP == null)
        {
            HP = ScriptableObject.CreateInstance<FloatVariable>();
        }
    }
}
