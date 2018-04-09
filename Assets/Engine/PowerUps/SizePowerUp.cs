using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizePowerUp : MonoBehaviour {
    public float sizeMultiplier = 3;
    public GameObject initialExplotion;
    public GameObject icon;
    private GameObject theConsumer;

    public void Appear() {
        initialExplotion.SetActive(true);
        icon.SetActive(true);
    }

    public void Consumed() {


    }

    public void Dissapear() {
        initialExplotion.SetActive(false);
        icon.SetActive(false);
    }
}
