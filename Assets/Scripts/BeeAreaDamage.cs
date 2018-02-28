using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAreaDamage : MonoBehaviour {
    public GameObject playerObject;
    public float beeDamageRadius;
    private Vector3 playerLocation;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		playerLocation = playerObject.transform.position;
    }

    void ExplosionDamage(Vector3 center, float radius) {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length) {
            hitColliders[i].SendMessage("AddDamage");
            i++;
        }
    }
}
