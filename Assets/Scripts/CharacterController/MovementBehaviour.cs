using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementBehaviour : MonoBehaviour {

    protected Rigidbody2D body;
    private CharController controller;

    public Vector2 direction;

    public bool disabled;
    public float maxspeed = 5;
    public float speed = 5;

    void Start() {
        controller = GetComponent<CharController>();
        body = GetComponent<Rigidbody2D>();
        disabled = false;
        init();
    }

    virtual protected void init() {

    }

    // Update is called once per frame
    void Update() {
        if (!(disabled || controller.IsMoveBlocked())) {
            bool input = false;
            if (controller.IsMoveInputBlocked()) {
                 input = UpdateMovementInput();
            }
            body.velocity = direction * speed;


            if (!input) {
                OnNoInput();
            }

            ClampToMaxSpeed();
        }
    }

    private void ClampToMaxSpeed() {
        if(body.velocity.magnitude > maxspeed) {
            float scale = maxspeed / body.velocity.magnitude;
            body.velocity = Vector2.Scale(body.velocity, Vector2.one * scale);
        }
    }

    private void OnNoInput() {
        body.velocity = Vector2.zero;
    }

    protected abstract bool UpdateMovementInput();
    

}
