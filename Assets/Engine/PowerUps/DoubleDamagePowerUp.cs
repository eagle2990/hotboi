using UnityEngine;
[RequireComponent(typeof(Animator))]
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

    public GameObject movingFire;
    public GameObject sparks;
    public GameObject baseFire;
    public GameObject smoke;
    public GameObject fireLight;

    private Animator animator;
    private ParticleSystem.MainModule movingFireModule;
    private ParticleSystem.MainModule sparksModule;
    private ParticleSystem.MainModule baseFireModule;
    private ParticleSystem.MainModule smokeModule;
    private FlickeringLight fireLightScript;




    private WeaponBasicData weaponStats;

    private void Start() {
        animator = GetComponent<Animator>();
        movingFireModule = movingFire.GetComponent<ParticleSystem>().main;
        sparksModule = sparks.GetComponent<ParticleSystem>().main;
        baseFireModule = baseFire.GetComponent<ParticleSystem>().main;
        smokeModule = smoke.GetComponent<ParticleSystem>().main;
        fireLightScript = fireLight.GetComponent<FlickeringLight>();
        animator.SetBool("appear", false);
        animator.SetBool("consumed", false);
        animator.SetBool("disappear", false);
    }

    public void Appear() {
        animator.SetBool("appear", true);
        //initialExplotion.SetActive(true);
        //icon.SetActive(true);
    }

    public void Consumed() {
        animator.SetBool("consumed", true);
        movingFireModule.startColor = newMovingFireColor;
        sparksModule.startColor = newSparksColor;
        baseFireModule.startColor = newBaseFireColor;
        smokeModule.startColor = newSmokeColor;
        fireLightScript.originalColor = newFireLightColor;
        //TODO change enemy attack
    }

    public void Dissapear() {
        animator.SetBool("disappear", true);
        //initialExplotion.SetActive(false);
        //icon.SetActive(false);
    }

    private GameObject[] FindPlayer() {
        return GameObject.FindGameObjectsWithTag("Player");
    }
}
