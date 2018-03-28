﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PowerUpSpawner : MonoBehaviour
{

    public List<GameObject> PowerUpPrefabs;
    public float range = 10.0f;

    private void Start()
    {
        InvokeRepeating("SpawnPowerUp", 5.0f, 10.0f);
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 2.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

    GameObject GetRandomPowerUp()
    {
        return PowerUpPrefabs[Random.Range(0, PowerUpPrefabs.Count)];
    }

    void SpawnPowerUp()
    {
        Vector3 point;
        if (RandomPoint(transform.position, range, out point))
        {
            Instantiate(GetRandomPowerUp(), point, Quaternion.identity);
        }
    }
}