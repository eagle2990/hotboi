using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaKillPowerUp : MonoBehaviour {

    public List<GameObject> EnemiesToBeKilled;
    [Range(0f, 20f)]
    public float KillRadius = 10f;
    public bool showDebugRadius;

    public void Appear() {
    }

    public void Consumed() {
        DoAreaDamage(gameObject.transform.position, KillRadius);
    }

    public void Dissapear() {
    }

    // Display the explosion radius
    void OnDrawGizmosSelected() {
        if (showDebugRadius) {
            Gizmos.color = new Color(1, 1, 0, 0.5F);
            Gizmos.DrawSphere(gameObject.transform.position, KillRadius);
        }
    }

    void DoAreaDamage(Vector3 center, float radius) {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (Collider col in hitColliders) {
            foreach (GameObject enemy in EnemiesToBeKilled) {
                if (col.name == string.Format("{0}(Clone)", enemy.name)) {
                    col.GetComponent<RecieveDamage>().DamageCalculation(gameObject.GetComponent<InflictDamage>());
                }
            }
        }
    }
}
