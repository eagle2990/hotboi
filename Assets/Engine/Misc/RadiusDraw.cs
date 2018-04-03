using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AreaKillPowerUp))]
public class RadiusDraw : MonoBehaviour {

    [Range(3, 256)]
    public int numSegments = 128;

    private float radius;
    private AreaKillPowerUp areaKillPowerUp;

    private void Update() {
        DoRenderer();
    }

    public void DoRenderer() {
        radius = gameObject.GetComponent<AreaKillPowerUp>().KillRadius;
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        Color c1 = new Color(0.5f, 0.5f, 0.5f, 1);
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.startColor = c1;
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.5f;
        lineRenderer.positionCount = numSegments + 1;
        lineRenderer.useWorldSpace = false;

        lineRenderer.endColor = c1 ;
        float deltaTheta = (float)(2.0 * Mathf.PI) / numSegments;
        float theta = 0f;

        for (int i = 0; i < numSegments + 1; i++) {
            float x = radius * Mathf.Cos(theta);
            float z = radius * Mathf.Sin(theta);
            Vector3 pos = new Vector3(x, 0, z);
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }
}
