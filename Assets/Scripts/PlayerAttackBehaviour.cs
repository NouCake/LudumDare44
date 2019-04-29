using UnityEngine;
using System.Collections;

public class PlayerAttackBehaviour : AttackBehaviour {

    private GameObject weapon;

    override protected void init(){
        weapon = transform.Find("Weapon").gameObject;
        weapon.SetActive(false);
    }

    override protected void InitHitbox() {
        attackHitbox = transform.Find("Weapon").Find("hb_weapon").GetComponent<Collider2D>();
    }

    protected override void OnAttackStart(){
        weapon.SetActive(true);
        controller.SetMoveInputBlocked(true);
    }

    protected override void OnAttackEnd() {
        weapon.SetActive(false);
        controller.SetMoveInputBlocked(false);
    }
    
}
