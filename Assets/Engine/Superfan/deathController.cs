using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class deathController : MonoBehaviour {
    private Animator animator;
    private NavMeshAgent navMesh;
    private CapsuleCollider collider;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
        collider = GetComponent<CapsuleCollider>();
	}
	
	// Update is called once per frame
	
    public void Die() {
        animator.SetBool("death", true);
        navMesh.isStopped = true;
        collider.enabled = false;
    }
}
