using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyBaseData : UnitBasicData
{
    public FloatReference WanderSpeed;
    public FloatVariable scoringPoints;

    private void OnEnable()
    {
    }
}
