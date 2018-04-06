using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour
{
    [TagSelector]
    public string tagFilter;
    public float lifetimeSeconds = 10;
    [Range(0f, 10f)]
    public float beginIntensity = 0f;
    [Range(0f, 10f)]
    public float finishIntensity = 5f;
    [Range(0f, 10f)]
    public float lightAppearTime = 4f;
    [Range(0f, 5f)]
    public float lightDisappearTime = 2f;
    public LayerMask collisionLayer;
    public UnityEvent appearsEvent;
    public UnityEvent consumedEvent;
    public UnityEvent dissapearsEvent;

    private Animator[] animators;
    private Collider objCollider;
    private float currentLifetime;
    //private new ParticleSystem.EmissionModule particleSystem;
    private Light pointLight;

    private void Start()
    {
        //particleSystem = gameObject.GetComponentInChildren<ParticleSystem>().emission;
        pointLight = gameObject.GetComponentInChildren<ParticleSystem>().gameObject.GetComponentInChildren<Light>();
        Appears();
        objCollider = GetComponent<Collider>();
        animators = GetComponentsInChildren<Animator>();
        foreach (Animator animator in animators) {
            animator.SetBool("consumed", false);
            animator.SetBool("disappear", false);
        }
    }

    void Appears()
    {
        appearsEvent.Invoke();
        StartCoroutine(FadeLight(beginIntensity, finishIntensity, lightAppearTime));
    }

    void GetConsumed()
    {
        foreach (Animator animator in animators) {
            animator.SetBool("consumed", true);
        }
        consumedEvent.Invoke();
    }

    void Dissapears()
    {
        foreach (Animator animator in animators) {
            animator.SetBool("disappear", true);
        }
        if (gameObject.GetComponentInChildren<ParticleSystem>() != null) {
            //particleSystem.enabled = false;
            objCollider.enabled = false;
            pointLight.GetComponentInParent<ParticleSystemAutoDestroy>().FadeOut();
            gameObject.GetComponentInChildren<ParticleSystem>().transform.parent = null;
            dissapearsEvent.Invoke();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsObjectFromLayer(other.gameObject) && DoesObjHasTag(other.gameObject))
        {
            GetConsumed();
            Dissapears();
        }
    }

    private void FixedUpdate()
    {
        currentLifetime += Time.fixedDeltaTime;
        if (currentLifetime >= lifetimeSeconds)
        {
            Dissapears();
        }
    }

    private bool IsObjectFromLayer(GameObject other)
    {
        return (collisionLayer.value & 1 << other.layer) != 0;
    }

    private bool DoesObjHasTag(GameObject other)
    {
        return tagFilter.Length > 0 ? other.CompareTag(tagFilter) : true;
    }

    IEnumerator FadeLight(float startIntensity, float endIntensity, float time) {

        float elapsed = 0f;

        while (elapsed < time) {
            pointLight.intensity = Mathf.Lerp(startIntensity, endIntensity, elapsed / time);
            elapsed += Time.deltaTime;
            yield return null;
        }
        pointLight.intensity = endIntensity;
    }
}
