using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnpoints;         // An array of the spawn points this enemy can spawn from.
    private SpawnpointChecker spawnpoint;
    private ArrayList invisibleSpawnpoints;
    Transform spawnplace;

    int i = 0;

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
    }


    void Spawn()
    {
        invisibleSpawnpoints = new ArrayList();
        //Check if spawnpoint is visible
        foreach (Transform sp in spawnpoints)
        {
            //if a spawnpoint is not visible, add it to the list
            if (!sp.GetComponent<SpawnpointChecker>().isVisible)
            {
                invisibleSpawnpoints.Add(sp);
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

    void SpawnEnemy()
    {
        Debug.Log(i);
        for (int i = 0; i < spawnpoints.Length; i++)
        {
            Vector3 result = Camera.main.WorldToScreenPoint(spawnpoints[i].transform.position);
            Debug.Log(string.Format("{0} ({1}) is inside the boundaries X: {2}, Y: {3}", spawnpoints[i].name, result, result.x < Screen.width && result.x > -Screen.width, result.y < Screen.height && result.y > -Screen.height));
        }
        i++;
    }
}