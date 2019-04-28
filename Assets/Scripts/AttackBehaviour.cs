using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour {

    public float AttackDuration = 0.75f;
    public float AttackCooldown = .5f;

    private float attackDurationTimer;
    private float attackCooldownTimer;

    private CharController controller;
    private Collider2D attackHitbox;

    private DamageableTracker tracker;

    private bool disabled;

    void Start() {
        controller = GetComponent<CharController>();
        if(controller == null) {
            Debug.Log(transform.name + " has no CharController");
        }

        disabled = false;
        tracker = new DamageableTracker();

        InitHitbox();
    }

    virtual protected void InitHitbox() {
        attackHitbox = transform.Find("Weapon").Find("hb_weapon").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update() {
        if (!disabled) {

            if (attackCooldownTimer <= 0) {
                if (AttackCondition()) {
                    Attack();
                }
            } else {
                attackCooldownTimer -= Time.deltaTime;
            }

            if(attackDurationTimer > 0) {
                attackDurationTimer -= Time.deltaTime;
            }

        }

        Debug.Log(isAttacking());
    }
    
    virtual protected bool AttackCondition() {
        return Input.GetKeyDown(KeyCode.Return);
        //return false;
    }

    private void Attack() {
        attackCooldownTimer += AttackCooldown;
        attackDurationTimer += AttackDuration;
        tracker.reset();
    }

    public bool isAttacking() {
        return attackDurationTimer > 0;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (isAttacking() && attackHitbox.IsTouching(collision)) {
            if(collision.tag == "damageable") {
                CharController cha = collision.GetComponentInParent<CharController>();
                if(cha == null) {
                    Debug.Log(collision.name + " does not have CharController");
                    return;
                }
                if (!tracker.HasDamageable(cha)) {
                    tracker.AddDamageable(cha);
                    DealDamage(cha);
                }
            }
        }
    }

    virtual protected void DealDamage(CharController target) {
        target.dmgBehav.DealPhysicalDamage(controller.stats);
    }

}
