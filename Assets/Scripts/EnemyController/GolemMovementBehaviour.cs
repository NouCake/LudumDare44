using UnityEngine;
using System.Collections;

public class GolemMovementBehaviour : EnemyMovementBehaviour {

    protected override void UpdateDirection() {
        Vector3 dir  = (Vector2)(player.transform.position - transform.position);
        dir = MyUtility.GetAxisOriented(dir);
        dir = (player.transform.position + dir * MinPlayerDistance) - transform.position;
        direction += (Vector2)dir;
        direction.Normalize();
    }

}
