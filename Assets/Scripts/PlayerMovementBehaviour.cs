using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MovementBehaviour {

    protected override bool UpdateMovementInput() {
        bool keydown = false;

        if(body.velocity.magnitude <= 0.05) {
            direction = Vector2.zero;
        }

        if (Input.GetKey(KeyCode.A)) {
            direction += Vector2.left;
            keydown = true;
        }
        if (Input.GetKey(KeyCode.D)){
            direction += Vector2.right;
            keydown = true;
        }

        if (Input.GetKey(KeyCode.W)) {
            direction += Vector2.up;
            keydown = true;
        }
        if (Input.GetKey(KeyCode.S)) {
            direction += Vector2.down;
            keydown = true;
        }

        direction.Normalize();

        return keydown;
    }

}

/*
 if (Input.GetKey(KeyCode.LeftArrow)) {
            return true;
        } else if (Input.GetKey(KeyCode.RightArrow)){
            return true;
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            return true;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            return true;
        }
     */
