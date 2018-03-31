using UnityEngine;
using EZCameraShake;

public class CameraShake : MonoBehaviour {
    public float Magnitude = 2f;
    public float Roughness = 10f;
    public float FadeInTime = 5f;
    public float FadeOutTime = 5f;

    public void ShakeOnce() {
        CameraShaker.Instance.ShakeOnce(Magnitude, Roughness, FadeInTime, FadeOutTime);
    }
}
