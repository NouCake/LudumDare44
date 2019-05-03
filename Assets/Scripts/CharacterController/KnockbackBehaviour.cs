using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackBehaviour : MonoBehaviour {

    public float KnockbackDistance = 2;
    public float KnockbackTime = 0.7f;
    public float KnockoutTime = 1;
    private float KnockbackDistanceTimer;

    private CharController controller;
    //private Vector2 direction;

    private Rigidbody2D body;

    private float timer;

    void Start() {
        timer = 0;
        //direction = Vector2.zero;
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        
        if(timer > 0) {
            KnockbackUpdate();
            timer -= Time.deltaTime;
            if(timer <= 0) {
                OnKnockbackOver();
            }
        }

    }

    private void KnockbackUpdate() {
        if(KnockbackDistanceTimer > 0){
            KnockbackDistanceTimer -= Time.deltaTime;
            if(KnockbackDistanceTimer < 0) {
                body.velocity = Vector2.zero;
            }
        }
    }

    /**
     * Knockout will not be additive
     */
    public void Knockback(Vector2 direction) {
        timer = KnockoutTime;

        direction.Normalize();
        body.velocity = direction * (KnockbackDistance / KnockbackTime);
        KnockbackDistanceTimer = KnockbackTime;

    }
    public void Knockback(Vector2 direction, float knockbacktime, float knockouttime){
        timer = knockouttime;

        direction.Normalize();
        body.velocity = direction * (KnockbackDistance / KnockbackTime);
        KnockbackDistanceTimer = knockbacktime;

    }

    private void OnKnockbackOver() {
        
    }

    public bool IsKnockedBack() {
        return timer > 0;
    }

}
