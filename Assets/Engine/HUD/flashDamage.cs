using UnityEngine;
using UnityEngine.UI;

public class flashDamage : MonoBehaviour {
    public Image damageImage;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public FloatReference flashSpeed;

    public void flashBlood() {
        print("flash");
        damageImage.color = flashColour;
        // ... transition the colour back to clear.
        damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
    }
}