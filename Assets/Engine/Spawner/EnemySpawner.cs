using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy; //List of enemy prefabs to be spawned
    public float spawnTime = 3f;            // How long between each spawn.
    public int spawnLimit = 3;
    public bool useDynamicSpawner;
    //how many seconds before limit rises.
    [Range(5f, 60f)]
    public float limitRiseTimeInSeconds = 20f;
    public int enemyCount = 0;
    public Transform[] spawnpoints;         // An array of the spawn points this enemy can spawn from.
    
    private float limitRiseTimer = 0f;
    private SpawnpointChecker spawnpoint;
    private ArrayList invisibleSpawnpoints;
    Transform spawnplace;


    void Start()
    {
        limitRiseTimer = limitRiseTimeInSeconds;
        invisibleSpawnpoints = new ArrayList();
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    private void Update() {
        limitRiseTimer -= Time.deltaTime; 
    }


    void Spawn(){
        if (limitRiseTimer <= 0f && useDynamicSpawner) {
            limitRiseTimer = limitRiseTimeInSeconds;
            spawnLimit += 1;
        }
        enemyCount = GameObject.FindGameObjectsWithTag(enemy.tag).Length;
        if (spawnLimit > enemyCount) {
            //Check if spawnpoint is visible
            foreach (Transform sp in spawnpoints)
            {
                //if a spawnpoint is not visible, add it to the list
                if (!sp.GetComponent<SpawnpointChecker>().isVisible) {
                    invisibleSpawnpoints.Add(sp);
                }
                if (sp.GetComponent<SpawnpointChecker>().isVisible) {
                    invisibleSpawnpoints.Remove(sp);
                }
            }

            // Find a random index between zero and one less than the number of invisible spawn points.
            int spawnPointIndex = Random.Range(0, invisibleSpawnpoints.Count);
            //If there is at least 1 invisible spawnpoint, spawn an enemy
            if (invisibleSpawnpoints.Count != 0)
            {
                spawnplace = (Transform)invisibleSpawnpoints[spawnPointIndex];
                Instantiate(enemy, spawnplace.position, spawnplace.rotation);
            }
        }
    }
}