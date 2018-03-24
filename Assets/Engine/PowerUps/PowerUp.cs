using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float lifetimeMiliseconds = 2;
    private float currentLifetime;
    public UnityEvent appearsEvent;
    public UnityEvent consumedEvent;
    public UnityEvent dissapearsEvent;

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
        Destroy(gameObject, 2.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer.Equals(collisionLayer.value))
        {
            GetConsumed();
            Dissapears();
        }
    }



    private void FixedUpdate()
    {
        currentLifetime += Time.fixedDeltaTime;
        if (currentLifetime >= lifetimeMiliseconds)
        {
            Dissapears();
        }
    }

    private void Start()
    {
        Appears();
    }
}
