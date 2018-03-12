using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystemCalculator : MonoBehaviour {

    public FloatVariable TotalScore;
    public FloatVariable TotalKills;
    private RecieveDamage DamageInfo;
    private EnemyBaseData Enemy;

    private void Start()
    {
        TotalScore.Value = 0;
        TotalKills.Value = 0;
        DamageInfo = GetComponent<RecieveDamage>();
        Enemy = (EnemyBaseData)DamageInfo.UnitStats;
    }

    public void AddEnemyPoints()
    {
        TotalKills.Add(1);
        TotalScore.Add((Enemy.scoringPoints));
    }
}
