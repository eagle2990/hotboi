using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFlasher : MonoBehaviour {
    
    public Light BombFlashLight;
    //Flash settings
    [Range(0f, 10f)]
    public float MaxIntensity;
    [Range(0f, 2f)]
    public float TimeFromZeroToFlash;
    [Range(0f, 5f)]
    public float TimeFromFlashToZero;
    
    private float minIntensity = 0f;
    //Flash position settings
    //Flash is always out of camera view
    [Range(0f, 100f)]
    public float MaxFlashDistance;
    [Range(0f, 2f)]
    public float MinFlashDistance;
    [Range(0f, 100f)]
    public float MaxFlashHeight;
    [Range(0f, 2f)]
    public float MinFlashHeight;


    private float randX;
    private float randY;
    private float randZ;
    private Vector3 randPos;
    private Transform target;

    private IEnumerator FlashNow() {
        //Find a random place out of sight to make a flash
        //rand sign + -
        randX = Random.Range(MinFlashDistance, MaxFlashDistance);
        randY = Random.Range(MinFlashHeight, MaxFlashHeight);
        randZ = Random.Range(MinFlashDistance, MaxFlashDistance);
        randPos = Camera.main.ViewportToWorldPoint(new Vector3(randX, 0f, randZ));
        randPos.x = randPos.x * GetRandSign();
        randPos.y = randY;
        randPos.z = randPos.z * GetRandSign();

        //change bomblight post
        BombFlashLight.transform.position = randPos;
        //Find player to point light at him
       target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        BombFlashLight.intensity = minIntensity;
        print(randPos);
        print(GetDistanceToBomb());

        BombFlashLight.transform.LookAt(target);
        while (BombFlashLight.intensity < MaxIntensity) {
            BombFlashLight.intensity += Time.deltaTime / TimeFromZeroToFlash;        // Increase intensity
            yield return null;
        }
        while (BombFlashLight.intensity > 0) {
            BombFlashLight.intensity -= Time.deltaTime / TimeFromFlashToZero;        //Decrease intensity
            yield return null;
        }
        yield return null;
    }

    public void Flash() {
        StartCoroutine(FlashNow());
    }

    private int GetRandSign() {
        return Random.Range(0, 2) * 2 - 1;
    }
    private float GetDistanceToBomb() {
        return Vector3.Distance(gameObject.transform.position, Camera.main.transform.position);
    }
}
