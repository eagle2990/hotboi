using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {
    public int secondsBeforeDeathScreen;
    private Animator animator;
    private DeathScreenController deathScreenController;
    //private CapsuleCollider collider;
    private PlayerController playerController;
    private CharacterController charController;
	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponentInParent<Animator>();
        charController = gameObject.GetComponentInParent<CharacterController>();
        deathScreenController = gameObject.GetComponent<DeathScreenController>();
        playerController = gameObject.GetComponentInParent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void Die() {
        StartCoroutine(DeathSequence(secondsBeforeDeathScreen));
    }
    IEnumerator DeathSequence(int seconds) {
        animator.SetBool("die", true);
        charController.enabled = false;
        playerController.enabled = false;
        yield return new WaitForSeconds(seconds);
        deathScreenController.ShowDeathScreen();
        Time.timeScale = 0;
    }

}
