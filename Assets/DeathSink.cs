using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeathSink : MonoBehaviour {
    public float waitTimeBeforeSink = 3f;
    public float sinkDepth = 10f;
    private bool sinking = false;

    public void SinkBody() {
        StartCoroutine(Sink());
    }

    private IEnumerator Sink() {
        Vector3 sinker = new Vector3(0f, 0f, 0f);
        for (int i = 0; i < sinkDepth; i++) {
            sinker.Set(transform.position.x, +12f, transform.position.z);
            transform.position = sinker;
            new WaitForSeconds(0.1f);
        }
        yield return null;
    }
}
