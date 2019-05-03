using UnityEngine;
using System.Collections;

public class PlayerAttackBehaviour : AttackBehaviour {

    private GameObject weapon;
    private DamageableInformation dmgInfo;

    override protected void init(){
        weapon = transform.Find("Weapon").gameObject;
        weapon.SetActive(false);


    }

    override protected void InitHitbox() {
        attackHitbox = transform.Find("Weapon").Find("hb_weapon").GetComponent<Collider2D>();
    }

    override protected bool AttackCondition() {
        return Input.GetKeyDown(KeyCode.Return);
    }

    protected override void OnAttackStart(){
        weapon.SetActive(true);
        controller.SetMoveInputBlocked(true);
        dmgInfo = new DamageableInformation(controller, transform, controller.TotalStats);
        //controller.knockBehav.Knockback(((PlayerController)controller).movement.GetDirectionAxisOriented());
    }

    protected override void OnAttackEnd() {
        weapon.SetActive(false);
        controller.SetMoveInputBlocked(false);
    }

    protected override void DealDamage(CharController target) {
        Debug.Log("Hello");
        target.dmgBehav.DealPhysicalDamage(dmgInfo);
    }

}
