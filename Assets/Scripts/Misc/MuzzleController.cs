using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleController : MonoBehaviour {

    public float CeaseTime = 0.25f;
    private float timer;
    private SpriteRenderer spr;

    void Start() {
        timer = CeaseTime;
        spr = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if(timer > 0) {
            timer -= Time.deltaTime;
            if(timer <= 0) {
                gameObject.SetActive(false);
            }
        }
        Debug.Log(timer);
    }

    public void reset() {
        timer = CeaseTime;
        gameObject.SetActive(true);
    }
}
