using UnityEngine;
using UnityEngine.Events;

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
        dissapearsEvent.Invoke();
        objCollider.enabled = false;
        Destroy(gameObject, 2.0f);
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
