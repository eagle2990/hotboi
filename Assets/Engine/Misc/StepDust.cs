using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepDust : MonoBehaviour {

    public ParticleSystem leftStepDust;
    public ParticleSystem rightStepDust;
    void Start() {
    }


    private void LeftStep() {
        leftStepDust.Play();
    }

    private void RightStep() {
        rightStepDust.Play();
    }
}
