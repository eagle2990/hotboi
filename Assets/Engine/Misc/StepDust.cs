using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepDust : MonoBehaviour {

    public ParticleSystem leftStepDust;
    public ParticleSystem rightStepDust;
    Animation animation;
    // Use this for initialization
    void Start() {
    }


    private void LeftStep() {
        leftStepDust.Play();
    }

    private void RightStep() {
        rightStepDust.Play();
    }
}
