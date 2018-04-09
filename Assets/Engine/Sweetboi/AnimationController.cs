using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {
    public int secondsBeforeDeathScreen;
    private Animator animator;
    public GameObject GameUI;
    private DeathScreenController deathScreenController;
    private PlayerController playerController;
    private CharacterController charController;

	void Start () {
        animator = gameObject.GetComponentInParent<Animator>();
        charController = gameObject.GetComponentInParent<CharacterController>();
        deathScreenController = GameUI.GetComponent<DeathScreenController>();
        playerController = gameObject.GetComponentInParent<PlayerController>();
    }
	
    public void Die() {
        StartCoroutine(DeathSequence(secondsBeforeDeathScreen));
    }

    IEnumerator DeathSequence(int seconds) {
        animator.SetBool("die", true);
        InflictDamage[] inflictDamageArray = gameObject.GetComponentInParent<Transform>().GetComponentsInChildren<InflictDamage>();
        foreach (InflictDamage idscript in inflictDamageArray) {
            idscript.enabled = false;
        }
        charController.enabled = false;
        playerController.enabled = false;
        yield return new WaitForSeconds(seconds);
        deathScreenController.ShowDeathScreen();
        Time.timeScale = 0;
    }

}
