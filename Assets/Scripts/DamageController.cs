using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour {

    public int str;
    public Collider2D DamagingHitbox;

    void Start() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "damageable" && DamagingHitbox.IsTouching(collision)) {
            CharController cha = collision.GetComponentInParent<CharController>();
            if(cha == null) {
                Debug.Log(collision.name + " does not have CharController");
                return;
            }
            cha.dmgBehav.DealAbsoluteDamage(str);
        }
    }


}
