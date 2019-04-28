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

            direction = player.transform.position - transform.position;
            direction.Normalize();

            return true;
        }

        return false;
    }
}
