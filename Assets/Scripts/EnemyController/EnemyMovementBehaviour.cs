using UnityEngine;
using System.Collections;

public class EnemyMovementBehaviour : MovementBehaviour {

    public float MaxPlayerDistance = 6;
    public float MinPlayerDistance = 1;

    protected PlayerController player;

    override protected void init() {
        player = PlayerController.get();
    }

    protected override bool UpdateMovementInput() {

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < MaxPlayerDistance && distance > MinPlayerDistance) {

            UpdateDirection();
            return true;
        }

        return false;
    }

    protected virtual void UpdateDirection() {
        direction += (Vector2)(player.transform.position - transform.position);
        direction.Normalize();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "damageable") {
            CharController cha = collision.GetComponentInParent<CharController>();
            if(cha != null && cha.tag == "Enemy") {
                Vector2 avoidance = transform.position - collision.transform.position;
                direction += avoidance.normalized;
                direction.Normalize();
            } else {
            }
        }
    }

}
