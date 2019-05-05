using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour {

    public float AttackDuration = 0.75f;
    public float AttackCooldown = .5f;

    private float attackDurationTimer;
    private float attackCooldownTimer;

    protected CharController controller;
    protected Collider2D attackHitbox;
    protected Vector2 attackDirection;

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
        init();
        attackDirection = Vector2.zero;
    }

    virtual protected void init() {

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
                    OnAttackStart();
                }
            } else {
                attackCooldownTimer -= Time.deltaTime;
            }

            if(attackDurationTimer > 0) {
                attackDurationTimer -= Time.deltaTime;
                if(attackDurationTimer <= 0) {
                    OnAttackEnd();
                }
            }

        }
    }
    
    virtual protected bool AttackCondition() {
        return false;
    }

    private void Attack() {
        attackCooldownTimer = AttackCooldown;
        attackDurationTimer = AttackDuration;
        tracker.reset();
    }

    virtual protected void OnAttackStart() {

    }

    virtual protected void OnAttackEnd() {

    }

    public bool isAttacking() {
        return attackDurationTimer > 0;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.tag == "damageable") {
            if (isAttacking() && attackHitbox.IsTouching(collision)) {
                CharController cha = collision.GetComponentInParent<CharController>();
                if(cha == null) {
                    Debug.Log(collision.name + " does not have CharController");
                    return;
                }
                if(controller.tag == cha.tag) return;
                if (!tracker.HasDamageable(cha)) {
                    tracker.AddDamageable(cha);
                    DealDamage(cha);
                }
            }
        }
    }

    virtual protected void DealDamage(CharController target) {
        target.DmgBehav.DealAbsoluteDamage(1);
    }

}
