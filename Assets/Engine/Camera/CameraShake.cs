using UnityEngine;
using EZCameraShake;
using System.Collections;

public class CameraShake : MonoBehaviour {
    [Range(0f, 4f)]
    public float Magnitude = 2f;
    [Range(0f, 10f)]
    public float Roughness = 10f;
    [Range(0f, 10f)]
    public float FadeInTime = 5f;
    [Range(0f, 10f)]
    public float FadeOutTime = 5f;
    [Range(0f, 2f)]
    public float DelayTime = 0.1f;

    public void ShakeOnce() {
        StartCoroutine(shakeWithDelay());
    }

    private IEnumerator shakeWithDelay() {
        yield return new WaitForSeconds(DelayTime);
        CameraShaker.Instance.ShakeOnce(Magnitude, Roughness, FadeInTime, FadeOutTime);
    }
}
