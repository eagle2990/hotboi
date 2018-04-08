using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    public int secondsBeforeDeathScreen;
    public GameObject GameUI;

    private Animator animator;
    private DeathScreenController deathScreenController;
    private PlayerController playerController;
    private CharacterController charController;
    private GameObject burningMan;
    private Animator burningManAnimator;

	void Start () {
        burningMan = GameObject.FindGameObjectsWithTag("Player")[0].transform.parent.Find("BurningMan").gameObject;
        animator = gameObject.GetComponentInParent<Animator>();
        if (burningMan.GetComponents<Animator>().Length > 1) {
            print("Too many animators on Hotboi, Mikk. Tell Reimo that u broke everything :'(");
        }
        burningManAnimator = burningMan.GetComponent<Animator>();
        charController = gameObject.GetComponentInParent<CharacterController>();
        deathScreenController = GameUI.GetComponent<DeathScreenController>();
        playerController = gameObject.GetComponentInParent<PlayerController>();
    }
	
    public void Die() {
        burningManAnimator.SetBool("isDead", true);
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
