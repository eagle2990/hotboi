using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float lifetimeSeconds = 2;
    private float currentLifetime;
    private Collider collider;
    public UnityEvent appearsEvent;
    public UnityEvent consumedEvent;
    public UnityEvent dissapearsEvent;

    private void Start()
    {
        Appears();
        collider = GetComponent<Collider>();
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
        collider.enabled = false;
        Destroy(gameObject, 2.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //print(other.gameObject.layer);
        if (IsObjectFromLayer(other.gameObject))
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
}
