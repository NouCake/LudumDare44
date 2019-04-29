using UnityEngine;
using System.Collections;

public class EnemyMovementBehaviour : MovementBehaviour {

    public int MaxPlayerDistance = 6;
    public int MinPlayerDistance = 1;

    private PlayerController player;

    override protected void init() {
        player = PlayerController.get();
    }

    protected override bool UpdateMovementInput() {

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < MaxPlayerDistance && distance > MinPlayerDistance) {
            
            direction += (Vector2)(player.transform.position - transform.position);
            direction.Normalize();

            return true;
        }

        return false;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "damageable") {
            CharController cha = collision.GetComponentInParent<CharController>();
            if(cha != null && cha.tag == "Enemy") {
                Vector2 avoidance = transform.position - collision.transform.position;
                direction += avoidance.normalized;
                direction.Normalize();
            }
        }
    }

}
