using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementBehaviour : MonoBehaviour {

    protected Rigidbody2D body;
    private CharController controller;

    public Vector2 direction;

    public bool disabled;
    public float maxspeed = 5;
    public float speed = 20;

    void Start() {
        controller = GetComponent<CharController>();
        body = GetComponent<Rigidbody2D>();
        disabled = false;
    }

    // Update is called once per frame
    void Update() {
        if (!disabled) {
            bool input = false;
            if (controller.isMoveInput()) {
                 input = UpdateMovementInput();
            }
            body.velocity += direction * speed * Time.deltaTime;


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
    
    public Vector2 GetDirectionAxisOriented() {

        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
            if(direction.x > 0) {
                return Vector2.right;
            }
            return Vector2.left;
        } else {
            if(direction.y < 0) {
                return Vector2.down;
            }
            return Vector2.up; //Base Direction if direction = (0,0)
        }
    }
    public int GetDirectionAxisOrientedAngle() {

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
            if (direction.x > 0) {
                return -90;
            }
            return 90;
        } else {
            if (direction.y < 0) {
                return 180;
            }
            return 0; //Base Direction if direction = (0,0)
        }
    }

}
