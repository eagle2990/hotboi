using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemiesPowerUp : MonoBehaviour {

    [Range(0.1f, 1f)]
    public float EnemySpeedMultiplier = 0.5f;
    [Range(1f, 20f)]
    public float EffectTimer = 10f;

    public Color newMovingFireColor;
    public Color newSparksColor;
    public Color newBaseFireColor;
    public Color newSmokeColor;
    public Color newFireLightColor;

    private Animator animator;
    private ParticleSystem.MainModule movingFire;
    private ParticleSystem.MainModule sparks;
    private ParticleSystem.MainModule baseFire;
    private ParticleSystem.MainModule smoke;
    private FlickeringLight fireLight;
    private GameObject fireParticleEffect;

    private WeaponBasicData weaponStats;

    private void Start() {

        fireParticleEffect = FindPlayer()[0].transform.parent.transform.Find("FireParticleEffect").gameObject;
        movingFire = fireParticleEffect.transform.Find("MovingFire").GetComponent<ParticleSystem>().main;
        sparks = fireParticleEffect.transform.Find("Sparks").GetComponent<ParticleSystem>().main;
        baseFire = fireParticleEffect.transform.Find("BaseFire").GetComponent<ParticleSystem>().main;
        smoke = fireParticleEffect.transform.Find("Smoke").GetComponent<ParticleSystem>().main;
        fireLight = fireParticleEffect.transform.Find("FireLight").GetComponent<FlickeringLight>();

    }

    void Update () {
		
	}

    public void Appear() {
    }

    public void Consumed() {
        movingFire.startColor = newMovingFireColor;
        sparks.startColor = newSparksColor;
        baseFire.startColor = newBaseFireColor;
        smoke.startColor = newSmokeColor;
        fireLight.originalColor = newFireLightColor;
        //TODO make enemies slow
    }

    public void Disappear() {
    }
    private GameObject[] FindPlayer() {
        return GameObject.FindGameObjectsWithTag("Player");
    }
}
