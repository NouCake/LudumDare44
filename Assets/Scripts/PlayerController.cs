using UnityEngine;
using System.Collections;

public class PlayerController : CharController{

    private PlayerMovementBehaviour movement;

    private GameObject DialogHitbox;

    override protected void init(){
        DialogHitbox = transform.Find("hb_dialog").gameObject;
        movement = GetComponent<PlayerMovementBehaviour>();
    }

    private void Update() {
        DialogHitbox.transform.localEulerAngles = Vector3.forward * movement.GetDirectionAxisOrientedAngle();
    }

}
