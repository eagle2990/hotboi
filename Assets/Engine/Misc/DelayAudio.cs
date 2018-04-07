using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class DelayAudio : MonoBehaviour {

    public new AudioSource audio;

    void Start() {

        audio.playOnAwake = false;

        if (audio.clip != null) {
            float delayTime = Random.Range(0, audio.clip.length);
            audio.time = delayTime;
            audio.Play();
        }
    }

}