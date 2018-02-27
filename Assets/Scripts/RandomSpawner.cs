using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour {
    //public Transform[] spawnLocations;
    public GameObject spawnee;
    //public GameObject[] whatToSpawnClone;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    //replace kui aru saad
    public float groundScaleFactor;

    void Start() {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        //Spawn();  
    }

    void SpawnObject() {
        //whatToSpawnClone[0] = Instantiate(whatToSpawnPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        //whatToSpawnPrefab[0] -> loopi, kui erinevad enemyd tulevad!!!!!!!!
        Vector3 position = new Vector3(Random.Range(-10.0f*groundScaleFactor, 10.0f*groundScaleFactor), 0, Random.Range(-10.0f * groundScaleFactor, 10.0f * groundScaleFactor));
        Instantiate(spawnee, position, Quaternion.identity);
        if (stopSpawning) {
            CancelInvoke("SpawnObject");
        }
    }
}
