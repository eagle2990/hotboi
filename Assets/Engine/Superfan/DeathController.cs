using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeathController : MonoBehaviour {
    private Animator animator;
    private NavMeshAgent navMesh;
    private CapsuleCollider objectCollider;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
        objectCollider = GetComponent<CapsuleCollider>();
	}
	
	// Update is called once per frame
	
    public void Die() {
        animator.SetBool("death", true);
        navMesh.isStopped = true;
        objectCollider.enabled = false;
    }
}
