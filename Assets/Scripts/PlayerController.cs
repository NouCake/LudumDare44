using UnityEngine;
using System.Collections;

public class PlayerController : CharController{

    private static PlayerController singleton;
    public static PlayerController get() {
        return singleton;
    }
    private void Awake() {
        if(singleton != null)
        {
            Debug.Log("Too Many UIController");
            return;
        }
        singleton = this;
    }

    private PlayerMovementBehaviour movement;

    private GameObject DialogHitbox;

    override protected void init(){
        DialogHitbox = transform.Find("hb_dialog").gameObject;
        movement = GetComponent<PlayerMovementBehaviour>();
    }

    override protected void ControllerUpdate() {
        DialogHitbox.transform.localEulerAngles = Vector3.forward * movement.GetDirectionAxisOrientedAngle();

        if (Input.GetKeyDown(KeyCode.Space)) {
            CurTestFunction();
        }
    }

    private void CurTestFunction() {

        dmgBehav.DealPoisonDamage(3);

    }

}
