using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamageBehaviour : MonoBehaviour {

    private DamageableInformation info;
    private CharController controller;

    void Start() {
        controller = GetComponent<CharController>();
        info = new DamageableInformation(controller, transform, controller.TotalStats);
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.tag == "damageable") {
            CharController other = collision.GetComponentInParent<CharController>();
            if(other == null) {
                Debug.Log("Could not find Controller");
                return;
            }
            if (controller.tag == other.tag) return;
            other.DmgBehav.DealPhysicalDamage(info);
        }
    }



}
