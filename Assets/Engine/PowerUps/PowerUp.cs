using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(ParticleSystem))]
public class PowerUp : MonoBehaviour
{
    public LayerMask collisionLayer;
    [TagSelector]
    public string tagFilter;
    public float lifetimeSeconds = 10;
    private float currentLifetime;
    private Collider objCollider;
    public UnityEvent appearsEvent;
    public UnityEvent consumedEvent;
    public UnityEvent dissapearsEvent;

    private void Start()
    {
        Appears();
        objCollider = GetComponent<Collider>();
    }


    void Appears()
    {
        appearsEvent.Invoke();
    }

    void GetConsumed()
    {
        consumedEvent.Invoke();
    }

    void Dissapears()
    {
        if (gameObject.GetComponentInChildren<ParticleSystem>() != null) {
            gameObject.GetComponentInChildren<ParticleSystem>().enableEmission = false;
            gameObject.GetComponentInChildren<ParticleSystem>().GetComponentInChildren<Light>().intensity = 0f;
            gameObject.GetComponentInChildren<ParticleSystem>().transform.parent = null;
            objCollider.enabled = false;
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
}
