using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFlasher : MonoBehaviour {

    //public Camera MainCamera;
    public GameObject Camera;
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
    [Range(0f, 100f)]
    public float MinFlashDistance;
    [Range(0f, 500f)]
    public float MaxFlashHeight;
    [Range(0f, 500f)]
    public float MinFlashHeight;
    [Range(1f, 300f)]
    public float DistanceRatio;

    private float randX;
    private float randY;
    private float randZ;
    private Vector3 randPos;
    private Transform target;
    private float magnitude = 1f;
    private float roughness = 1f;

    private IEnumerator FlashNow() {
        //Find a random place out of sight to make a flash
        //rand sign + -
        randX = Random.Range(MinFlashDistance, MaxFlashDistance);
        randY = Random.Range(MinFlashHeight, MaxFlashHeight);
        randZ = Random.Range(MinFlashDistance, MaxFlashDistance);
        randPos = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(randX, 0f, randZ));
        randPos.x *= GetRandSign();
        randPos.y = randY;
        randPos.z *= GetRandSign();

        //change bomblight pos
        BombFlashLight.transform.position = randPos;
        //Find player to point light at him
       target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        BombFlashLight.intensity = minIntensity;

        BombFlashLight.transform.LookAt(target);
        SetCameraShakeRelativeToBombDistance();
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
    private float GetDistanceToFlash(GameObject go) {
        return Vector3.Distance(go.transform.position, BombFlashLight.transform.position);
    }
    private void SetCameraShakeRelativeToBombDistance() {
        //calc multiplier
        magnitude = DistanceRatio / GetDistanceToFlash(Camera);
        roughness = DistanceRatio / GetDistanceToFlash(Camera);
        //update camerashake stats
        Camera.GetComponent<CameraShake>().Magnitude = magnitude;
        //Camera.GetComponent<CameraShake>().Roughness = roughness;

    }
}
