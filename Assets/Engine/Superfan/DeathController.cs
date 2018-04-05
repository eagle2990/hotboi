using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeathController : MonoBehaviour {
    private Animator animator;
    public GameObject teddy;
    private Animator burnAnimator;
    private NavMeshAgent navMesh;
    private CapsuleCollider objectCollider;

    void Start () {
        animator = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
        objectCollider = GetComponent<CapsuleCollider>();
        if (teddy != null) {
            burnAnimator = gameObject.transform.Find("Teddy").GetComponent<Animator>();
        }
	}
	
	
    public void Die() {
        animator.SetBool("death", true);
        if (teddy != null) {
            burnAnimator.SetBool("burn", true);
        }
        navMesh.isStopped = true;
        objectCollider.enabled = false;
    }
}
