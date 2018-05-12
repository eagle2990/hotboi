using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeathController : MonoBehaviour {
    [Range(1f, 20f)]
    private float waitTimeBeforeSink = 7f;
    public GameObject teddy;
    
    private Animator animator;
    private Animator burnAnimator;
    private NavMeshAgent navMesh;
    private CapsuleCollider objectCollider;
    private new Rigidbody rigidbody;
    private bool isDead;

    void Start () {
        animator = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
        objectCollider = GetComponent<CapsuleCollider>();
        rigidbody = GetComponent<Rigidbody>();
        if (teddy != null) {
            burnAnimator = gameObject.transform.Find("Teddy").GetComponent<Animator>();
        }
	}
	
	
    public void Die() {
        animator.SetBool("death", true);
        if (teddy != null) {
            burnAnimator.SetBool("burn", true);
        }
        objectCollider.enabled = false;
        navMesh.isStopped = true;
        isDead = true;
        StartCoroutine(Sink());
    }

    private IEnumerator Sink() {
        yield return new WaitForSeconds(waitTimeBeforeSink);
        rigidbody.isKinematic = false;
        DestroyObject(gameObject, 2f);
    }

}
