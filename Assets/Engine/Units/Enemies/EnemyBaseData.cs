using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyBaseData : UnitBasicData
{
    public FloatVariable Damage;
    public FloatVariable scoringPoints;

    private void OnEnable()
    {
    }
}
