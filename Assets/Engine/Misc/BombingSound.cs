using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombingSound : MonoBehaviour {
    private AudioSource audioSource;
    public List<AudioClip> bombSounds;
    private AudioClip bombSound;
    private int randClipIndex;

    private void Start() {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayRandom() {
        randClipIndex = Random.Range(0, bombSounds.Count-1);
        bombSound = bombSounds[randClipIndex];
        audioSource.PlayOneShot(bombSound);
    }
}
