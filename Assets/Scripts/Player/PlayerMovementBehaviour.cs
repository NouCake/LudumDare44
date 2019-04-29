using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MovementBehaviour {

    protected override bool UpdateMovementInput() {
        bool keydown = false;
        Vector2 cur = Vector2.zero;
        if (Input.GetKey(KeyCode.A)) {
            cur += Vector2.left;
            keydown = true;
        }
        if (Input.GetKey(KeyCode.D)){
            cur += Vector2.right;
            keydown = true;
        }

        if (Input.GetKey(KeyCode.W)) {
            cur += Vector2.up;
            keydown = true;
        }
        if (Input.GetKey(KeyCode.S)) {
            cur += Vector2.down;
            keydown = true;
        }
        //direction = cur;


        if (keydown){
            direction = cur;
        }

        direction.Normalize();

        return keydown;
    }

}