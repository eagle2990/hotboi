using UnityEngine;
using System.Collections;

public class ParticleSystemAutoDestroy : MonoBehaviour {

    public void Destroy() {
        Destroy(gameObject, GetComponent<ParticleSystem>().main.duration);
    }

}