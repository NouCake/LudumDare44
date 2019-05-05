using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaker : MonoBehaviour {

    private static ScreenShaker shaker;
    private void Awake() {
        shaker = this;
    }

    private Vector3 BasePosition;
    private float ShakeIntensity;
    private float ShakeTimer;
    private int FramesPerShake = 3;
    private int frameCounter;

    void Start() {
        BasePosition = transform.position;
    }

    private void Update() {
        if(ShakeTimer > 0) {
            ShakeTimer -= Time.deltaTime;
            frameCounter++;
            if(frameCounter >= FramesPerShake) {
                frameCounter = 0;
                transform.position = BasePosition;
                transform.position += Random.insideUnitSphere * ShakeIntensity;
            }
            if(ShakeTimer <= 0) {
                transform.position = BasePosition;
            }
        }
    }

    public static void Shake(float time, float intensity, int FramesPerShake) {
        shaker.ShakeTimer = time;
        shaker.ShakeIntensity = intensity;
        shaker.FramesPerShake = FramesPerShake;
    }

    public static void Shake(float time, float intensity) {
        Shake(time, intensity, 3);
    }

}
