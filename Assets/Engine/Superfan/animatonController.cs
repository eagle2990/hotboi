using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatonController : MonoBehaviour {
    private Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	
    public void Die() {
        animator.SetBool("death", true);
    }
}
