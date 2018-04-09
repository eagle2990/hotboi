using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlashDamage : MonoBehaviour {
    private Image[] blinkImages;
    public GameObject flashDamage;
    public Color startColor;
    public int blinkCount;
    public float blinkDuration;
    private Image blinkImage;
    private bool canFlash;

    void Start() {
        canFlash = true;
        blinkImages = flashDamage.GetComponentsInChildren<Image>();
    }

    public void Flash() {
        if (canFlash) {
            canFlash = false;
            blinkImage = blinkImages[Random.Range(0, blinkImages.Length)];
            //blinkImage.transform.position = new Vector3(-Random.Range(0, Screen.width), -Random.Range(0, Screen.height), 0);
            StartCoroutine(Blink(Color.red, blinkCount, blinkDuration));
        }
    }

    public IEnumerator ColorLerpTo(Color _color, float _duration) {

        float elapsedTime = 0.0f;
        while (elapsedTime < _duration) {
            blinkImage.color = Color.Lerp(blinkImage.color, _color, (elapsedTime / _duration * 0.5f));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator Blink(Color _blinkIn, int _blinkCount, float _totalBlinkDuration) {
        // We divide the whole duration for the ammount of blinks we will perform
        float fractionalBlinkDuration = _totalBlinkDuration / _blinkCount;
        for (int blinked = 0; blinked < _blinkCount; blinked++) {
            // Each blink needs 2 lerps: we give each lerp half of the duration allocated for 1 blink
            float halfFractionalDuration = fractionalBlinkDuration * 0.5f;

            // Lerp to the color
            yield return StartCoroutine(ColorLerpTo(_blinkIn, halfFractionalDuration));

            // Lerp to transparent
            yield return StartCoroutine(ColorLerpTo(Color.clear, halfFractionalDuration));
        }
        canFlash = true;

    }
}