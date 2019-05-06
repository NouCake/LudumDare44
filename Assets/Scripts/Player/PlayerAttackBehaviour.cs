using UnityEngine;
using System.Collections;

public class PlayerAttackBehaviour : AttackBehaviour {

    private GameObject weapon;
    private DamageableInformation dmgInfo;
    private PlayerController pController;

    public float ForwardDistance;
    public float ForwardTime;

    override protected void init(){
        weapon = transform.Find("Weapon").gameObject;
        weapon.SetActive(false);

        pController = (PlayerController)base.controller;
    }

    override protected void InitHitbox() {
        attackHitbox = transform.Find("Weapon").Find("hb_weapon").GetComponent<Collider2D>();
    }

    override protected bool AttackCondition() {
        return Input.GetKeyDown(KeyCode.Return);
    }

    protected override void OnAttackStart(){
        weapon.SetActive(true);
        pController.SetMoveInputBlocked(true);
        dmgInfo = new DamageableInformation(pController, transform, pController.TotalStats);
    }

    protected override void OnAttackEnd() {
        weapon.SetActive(false);
        pController.SetMoveInputBlocked(false);
    }

    protected override void DealDamage(CharController target) {
        target.DmgBehav.DealPhysicalDamage(dmgInfo);
        MuzzleSpawner.Spawn(target.transform.position);
        ScreenShaker.Shake(.2f, .1f);
    }

}
