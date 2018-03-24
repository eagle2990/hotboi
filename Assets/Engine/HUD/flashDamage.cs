using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlashDamage : MonoBehaviour {
    public Image damageImage;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public float flashSpeed = 5f;
    //public float flashSpeed;
    bool isIncrementing;
    //private float timer = 0.4f;

    //public void flashBlood() {
    //    StartCoroutine(quickFlash());
    //}
    
    //IEnumerator quickFlash() {
    //    if (isIncrementing) {
    //        //while (timer <= 1.0f) {
    //        //    damageImage.color = flashColour;
    //        //    Color.Lerp(flashColour, Color.clear, timer);
    //        //    timer += flashSpeed*Time.deltaTime;
    //        //    yield return null;
    //        //}
    //        isIncrementing = false;

    //    } else {
    //        //while (timer >= 0.0f) {
    //        //    Color.Lerp(Color.clear, flashColour, timer);
    //        //    timer -= flashSpeed*Time.deltaTime;
    //        //    yield return null;
    //        //}
    //    }



    //}
}