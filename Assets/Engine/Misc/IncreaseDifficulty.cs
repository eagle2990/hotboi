using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDifficulty : MonoBehaviour
{

    public UserData data;
    public List<WeaponBasicData> enemyDamage;
    [Range(1, 10)]
    public float difficultyMultiplier = 1.1f;
    public float acummulatedPointsToTrigger = 200f;

    void Start()
    {
        RestartDifficulty();
    }

    void Update()
    {
        if (HasTheScoreBeingAchieved())
        {
            IncreaseDamageOfEnemies();
            IncreaseLevel();
        }
    }

    private bool HasTheScoreBeingAchieved()
    {
        return data.score.Value >= (acummulatedPointsToTrigger * data.level.Value);
    }

    private void RestartLevel()
    {
        data.level.SetValue(1f);
    }

    private void IncreaseLevel()
    {
        data.level.SetValue(data.level.Value + 1);
    }

    private void IncreaseDamageOfEnemies()
    {
        ModifyEnemiesCurrentDamage(difficultyMultiplier * data.level.Value);
    }

    private void ResetToInitialDamage()
    {
        ModifyEnemiesCurrentDamage(1);
    }

    public void RestartDifficulty()
    {
        RestartLevel();
        ResetToInitialDamage();
    }

    private void ModifyEnemiesCurrentDamage(float multiplier)
    {
        for (int i = 0; i < enemyDamage.Count; i++)
        {
            enemyDamage[i].CurrentDamage.ConstantValue = enemyDamage[i].InitialDamage * multiplier;
        }
    }
}
