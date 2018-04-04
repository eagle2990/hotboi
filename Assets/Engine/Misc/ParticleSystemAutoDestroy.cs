using UnityEngine;
using System.Collections;

public class ParticleSystemAutoDestroy : MonoBehaviour {
    [Range(0f, 5f)]
    public float lightDisappearTime = 3.5f;
    private Light pointLight;

    private void Start() {
        pointLight = GetComponentInChildren<Light>();
    }

    public void FadeOut() {
        StartCoroutine(FadeLight(pointLight.intensity, 0f, GetComponent<ParticleSystem>().main.duration - lightDisappearTime));
    }

    private IEnumerator FadeLight(float startIntensity, float endIntensity, float time) {

        float elapsed = 0f;

        Destroy(gameObject, GetComponent<ParticleSystem>().main.duration);
        while (elapsed < time) {
            pointLight.intensity = Mathf.Lerp(startIntensity, endIntensity, elapsed / time);
            elapsed += Time.deltaTime;
            yield return null;
        }
        pointLight.intensity = endIntensity;
    }
}