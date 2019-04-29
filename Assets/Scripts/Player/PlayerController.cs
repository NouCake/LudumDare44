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
    private GameObject Weapon;

    override protected void init(){
        DialogHitbox = transform.Find("hb_dialog").gameObject;
        Weapon = transform.Find("Weapon").gameObject;
        movement = GetComponent<PlayerMovementBehaviour>();
        
    }

    override protected void ControllerUpdate() {
        int angle = movement.GetDirectionAxisOrientedAngle();
        DialogHitbox.transform.localEulerAngles = Vector3.forward * angle;
        Weapon.transform.localEulerAngles = Vector3.forward * angle;
        if (Input.GetKeyDown(KeyCode.Space)) {
            CurTestFunction();
        }
    }

    private void CurTestFunction() {

        dmgBehav.DealPoisonDamage(3);

    }

}
