using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeathController : MonoBehaviour {
    private Animator animator;
    public GameObject burnAnimatorParent;
    private Animator burnAnimator;
    private NavMeshAgent navMesh;
    private CapsuleCollider objectCollider;

    void Start () {
        animator = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
        objectCollider = GetComponent<CapsuleCollider>();
        if (burnAnimatorParent != null) {
            burnAnimator = burnAnimatorParent.GetComponent<Animator>();
        }
	}

    public void Die() {
        if (burnAnimator != null) {
            burnAnimator.SetBool("burn", true);
        }
        animator.SetBool("death", true);
        navMesh.isStopped = true;
        objectCollider.enabled = false;
    }
}
