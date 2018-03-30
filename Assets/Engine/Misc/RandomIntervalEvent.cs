using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomIntervalEvent : MonoBehaviour {

    public float leastSecondsBetweenEvents = 10f;
    public float mostSecondsBetweenEvents = 30f;
    private float randomTime;
    public UnityEvent randomEvent;

    private void Start(){
        randomTime = Random.Range(leastSecondsBetweenEvents, mostSecondsBetweenEvents);
        Invoke("RandomThing", randomTime);
    }

    private void RandomThing() {
        randomEvent.Invoke();
        randomTime = Random.Range(leastSecondsBetweenEvents, mostSecondsBetweenEvents);
        Invoke("RandomThing", randomTime);

     }
}
