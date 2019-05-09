using UnityEngine;
using System.Collections;

public class SentryAttackBehaviour : AttackBehaviour {

    public int Shots;
    public GameObject Arrow;
    public float ArrowSpeed = 6;

    private float shotTime;
    private int shotCounter;
    private SentryMovementBehaviour move;

    protected override void init() {
        base.init();
        shotTime = AttackDuration / (Shots +1);
        move = GetComponent<SentryMovementBehaviour>();
    }

    protected override void WhileAttacking() {
        int last = (int)(attackDurationTimer / shotTime);
        int cur = (int)((attackDurationTimer - Time.deltaTime) / shotTime);

        if(last != cur) {
            if(shotCounter < Shots) {
                Shoot();
                shotCounter++;
            }
        }

    }

    protected override void OnAttackStart() {
        controller.SetMoveInputBlocked(true);
        shotCounter = 0;
    }

    protected override void OnAttackEnd() {
        controller.SetMoveInputBlocked(false);
    }

    protected override bool AttackCondition() {
        return move.HasPreferedPosition();
    }

    private void Shoot() {
        GameObject o = Instantiate(Arrow);
        o.transform.position = transform.position;
        ArrowBehaviour arr = o.GetComponent<ArrowBehaviour>();
        Vector2 dir = MyUtility.GetAxisOriented(PlayerController.get().transform.position - transform.position);
        arr.Shoot(controller, dir.normalized, ArrowSpeed);
    }

    private void OnTriggerStay2D(Collider2D collision) {
        
    }

    protected override void InitHitbox() {
    }

}
