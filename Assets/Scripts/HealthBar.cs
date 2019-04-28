using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public CharController controller;

    private Transform bar;


    void Start() {
        bar = transform.Find("Bar");
    }

    private void Update() {
        UpdateHealth(controller.stats.GetCurHealth() / (float)controller.stats.GetMaxHealth());
    }

    public void UpdateHealth(float percent) {
        bar.localScale = new Vector3(percent, 1, 1);
    }

}
