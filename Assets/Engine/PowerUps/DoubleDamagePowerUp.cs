using UnityEngine;
[RequireComponent(typeof(Animator))]
public class DoubleDamagePowerUp : MonoBehaviour {
    public PlayerBaseData playerStats;
    [Range(5f, 30f)]
    public float damageDuration = 10f;
    public float damageMultiplier = 2f;
    public GameObject initialExplotion;
    public GameObject icon;
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
        movingFire.startColor = newMovingFireColor;
        sparks.startColor = newSparksColor;
        baseFire.startColor = newBaseFireColor;
        smoke.startColor = newSmokeColor;
        fireLight.originalColor = newFireLightColor;
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
