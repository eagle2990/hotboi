using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSound : MonoBehaviour {

    private AudioSource audioSource;
    public List<AudioClip> dieSounds;
    private AudioClip dieSound;
    private int randClipIndex;

    private void Start() {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayRandom() {
        randClipIndex = Random.Range(0, dieSounds.Count - 1);
        dieSound = dieSounds[randClipIndex];
        audioSource.PlayOneShot(dieSound);
    }
}
