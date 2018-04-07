using UnityEngine;

public class DoubleDamagePowerUp : MonoBehaviour {
    public PlayerBaseData playerStats;
    [Range(5f, 30f)]
    public float damageDuration = 10f;
    public float damageMultiplier = 2f;
    private GameObject fireParticleEffect;
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

    private WeaponBasicData weaponStats;

    private void Start() {

        fireParticleEffect = FindPlayer()[0].transform.parent.transform.Find("FireParticleEffect").gameObject;
        movingFire = fireParticleEffect.transform.Find("MovingFire").GetComponent<ParticleSystem>().main;
        sparks = fireParticleEffect.transform.Find("Sparks").GetComponent<ParticleSystem>().main;
        baseFire = fireParticleEffect.transform.Find("BaseFire").GetComponent<ParticleSystem>().main;
        smoke = fireParticleEffect.transform.Find("Smoke").GetComponent<ParticleSystem>().main;
        fireLight = fireParticleEffect.transform.Find("FireLight").GetComponent<FlickeringLight>();

    }

    public void Appear() {
    }

    public void Consumed() {
        movingFire.startColor = newMovingFireColor;
        sparks.startColor = newSparksColor;
        baseFire.startColor = newBaseFireColor;
        smoke.startColor = newSmokeColor;
        fireLight.originalColor = newFireLightColor;
        //TODO change enemy attack
    }

    public void Disappear() {
    }

    private GameObject[] FindPlayer() {
        return GameObject.FindGameObjectsWithTag("Player");
    }
}
